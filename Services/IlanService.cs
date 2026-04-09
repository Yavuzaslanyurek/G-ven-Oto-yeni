using GuvenOto.Models;
using GuvenOto.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuvenOto.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;
        private readonly IRepository<IlanOzellikDegeri> _featureValueRepository;

        public ListingService(IListingRepository listingRepository, IRepository<IlanOzellikDegeri> featureValueRepository)
        {
            _listingRepository = listingRepository;
            _featureValueRepository = featureValueRepository;
        }

        public async Task<IEnumerable<Ilan>> GetFilteredListingsAsync(int? MarkaId, int? AracModeliId, int? cityId, decimal? minPrice, decimal? maxPrice, int? minKm, int? maxKm, int? minYear, int? maxYear)
        {
            var query = _listingRepository.GetListingsWithIncludesQuery();

            if (MarkaId.HasValue && MarkaId > 0)
                query = query.Where(l => l.AracModeli != null && l.AracModeli.MarkaId == MarkaId);

            if (AracModeliId.HasValue && AracModeliId > 0)
                query = query.Where(l => l.AracModeliId == AracModeliId);

            if (cityId.HasValue && cityId > 0)
                query = query.Where(l => l.CityId == cityId);

            if (minPrice.HasValue)
                query = query.Where(l => l.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(l => l.Price <= maxPrice.Value);

            if (minKm.HasValue)
                query = query.Where(l => l.Kilometer >= minKm.Value);

            if (maxKm.HasValue)
                query = query.Where(l => l.Kilometer <= maxKm.Value);

            if (minYear.HasValue)
                query = query.Where(l => l.Year >= minYear.Value);

            if (maxYear.HasValue)
                query = query.Where(l => l.Year <= maxYear.Value);

            return await query.OrderByDescending(l => l.CreatedDate).ToListAsync();
        }

        public async Task<Ilan?> GetListingDetailsAsync(int id)
        {
            return await _listingRepository.GetListingWithDetailsAsync(id);
        }

        public async Task<IEnumerable<Ilan>> GetUserListingsAsync()
        {
            return await _listingRepository.GetListingsWithIncludesQuery().OrderByDescending(l => l.CreatedDate).ToListAsync();
        }

        public async Task AddListingAsync(Ilan ilan, int[] selectedFeatures, Dictionary<int, string> FeatureValues)
        {
            ilan.CreatedDate = DateTime.Now;
            await _listingRepository.AddAsync(ilan);
            await _listingRepository.SaveChangesAsync();

            if (selectedFeatures != null)
            {
                foreach (var fId in selectedFeatures)
                {
                    await _featureValueRepository.AddAsync(new IlanOzellikDegeri
                    {
                        // Hata CS0117 Çözümü: IlanId -> IlanID veya IlanId (Büyük/Küçük harf duyarlı olabilir)
                        // Önceki hatanda 'IlanId' ve 'FeatureId' bulunamadı diyordu.
                        // Senin modelinde büyük ihtimalle 'OzellikId' olarak geçiyor.
                        IlanId = ilan.Id,
                        OzellikId = fId,
                        Value = "Evet"
                    });
                }
            }

            if (FeatureValues != null)
            {
                foreach (var item in FeatureValues)
                {
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        await _featureValueRepository.AddAsync(new IlanOzellikDegeri
                        {
                            IlanId = ilan.Id,
                            OzellikId = item.Key,
                            Value = item.Value
                        });
                    }
                }
            }
            await _featureValueRepository.SaveChangesAsync();
        }

        public async Task RemoveListingAsync(int id)
        {
            var ilan = await _listingRepository.GetByIdAsync(id);
            if (ilan != null)
            {
                // Hata CS1061 Çözümü: Find yerine Query() kullanıyoruz
                var featureValues = await _featureValueRepository.Query()
                    .Where(f => f.IlanId == id).ToListAsync();

                foreach (var fv in featureValues)
                {
                    // Hata CS1061 Çözümü: Delete yerine Remove kullanıyoruz
                    _featureValueRepository.Remove(fv);
                }

                _listingRepository.Remove(ilan);
                await _listingRepository.SaveChangesAsync();
            }
        }
    }
}


