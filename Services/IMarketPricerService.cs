using GuvenOto.Models;
using System.Threading.Tasks;

namespace GuvenOto.Services
{
    public enum MarketStatus
    {
        PiyasaAlti,   // Ucuz (Alt)
        PiyasaAyarinda, // Normal
        PiyasaUstu   // Pahalı (Üst)
    }

    public class MarketEvaluationResult
    {
        public MarketStatus Status { get; set; }
        public decimal ExpectedMarketPrice { get; set; } // Hesaplanmış tahmini değer
        public decimal BaseAveragePrice { get; set; }    // Diğer araçların dümdüz ortalaması
        public decimal PriceDifferencePercentage { get; set; } // Olması gerekene göre fark
        public string EvaluationMessage { get; set; } = string.Empty;
    }

    public interface IMarketPricerService
    {
        Task<MarketEvaluationResult?> EvaluateListingPriceAsync(int AracModeliId, int year, int kilometer, decimal currentPrice);
    }
}

