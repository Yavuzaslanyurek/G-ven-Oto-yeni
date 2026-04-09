using GuvenOto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuvenOto.Services
{
    public interface IListingService
    {
        Task<IEnumerable<Ilan>> GetFilteredListingsAsync(int? MarkaId, int? AracModeliId, int? cityId, decimal? minPrice, decimal? maxPrice, int? minKm, int? maxKm, int? minYear, int? maxYear);
        Task<Ilan?> GetListingDetailsAsync(int id);
        Task<IEnumerable<Ilan>> GetUserListingsAsync();
        Task AddListingAsync(Ilan ilan, int[] selectedFeatures, Dictionary<int, string> FeatureValues);
        Task RemoveListingAsync(int id);
    }
}


