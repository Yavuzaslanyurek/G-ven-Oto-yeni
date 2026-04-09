using GuvenOto.Models;
using GuvenOto.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GuvenOto.Services
{
    public class MarketPricerService : IMarketPricerService
    {
        private readonly IListingRepository _listingRepository;

        public MarketPricerService(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }

        public async Task<MarketEvaluationResult?> EvaluateListingPriceAsync(int AracModeliId, int year, int kilometer, decimal currentPrice)
        {
            // Aynı Modele ait piyasadaki tüm araçları çekiyoruz
            var marketListings = await _listingRepository.Query()
                .Where(l => l.AracModeliId == AracModeliId && l.IsActive)
                .Select(l => new { l.Price, l.Year, l.Kilometer })
                .ToListAsync();

            if (marketListings.Count < 3) 
            {
                // Yeterli veri yoksa değerlendirme yapamıyoruz
                return null;
            }

            // Piyasanın dümdüz ortalamalarını bulalım
            decimal baseAveragePrice = marketListings.Average(x => x.Price);
            decimal averageKm = (decimal)marketListings.Average(x => x.Kilometer);
            decimal averageYear = (decimal)marketListings.Average(x => x.Year);

            decimal expectedPrice = baseAveragePrice;

            // KULLANICININ İSTEDİĞİ HARİKA FORMÜL!

            // 1. Yıl Farkı Etkisi: İlanın yılı ortalamadan yeniyse, her yıl için %5 değer ekle. Ekiyse %5 düş.
            decimal yearDiff = year - averageYear;
            if (yearDiff != 0) 
            {
                expectedPrice += (expectedPrice * 0.05m * yearDiff);
            }

            // 2. KM Farkı Etkisi: İlanın KM'si ortalamadan altındaysa (daha iyiyse), her 10.000 KM için %1.5 değer ekle. Üstündeyse düş.
            decimal kmDiff = averageKm - kilometer; // Örn: Ortalama 150k, İlan 100k -> +50k fark (iyi bir şey)
            if (kmDiff != 0)
            {
                decimal kmMultiplier = (Math.Floor(kmDiff / 10000m)) * 0.015m;
                expectedPrice += (expectedPrice * kmMultiplier);
            }

            // Hesaplanan hedeflenen (Expected) fiyat ile şu anki fiyatın kıyaslanması
            decimal difference = currentPrice - expectedPrice;
            decimal percentageDiff = (difference / expectedPrice) * 100;

            MarketStatus status;
            string message;

            if (percentageDiff < -5)
            {
                status = MarketStatus.PiyasaAlti; // %5'ten daha ucuz
                message = "Bu aracın KM ve Yılına göre piyasa değeri hesaplandığında, beklenen rakamın çok ALTINDA bir fiyat (Kelepir!).";
            }
            else if (percentageDiff > 5)
            {
                status = MarketStatus.PiyasaUstu; // %5'ten daha pahalı
                message = "Bu aracın KM ve Yılına göre piyasa değeri hesaplandığında, beklenen değerin ÜZERİNDE bir fiyat.";
            }
            else
            {
                status = MarketStatus.PiyasaAyarinda; // ±%5 aralığında
                message = "Bu aracın KM ve Yılına göre fiyatı tam PİYASA DEĞERİNDE.";
            }

            return new MarketEvaluationResult
            {
                Status = status,
                ExpectedMarketPrice = Math.Round(expectedPrice, 0),
                BaseAveragePrice = Math.Round(baseAveragePrice, 0),
                PriceDifferencePercentage = Math.Round(percentageDiff, 2),
                EvaluationMessage = message
            };
        }
    }
}

