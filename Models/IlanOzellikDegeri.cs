using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Bunu ekledik

namespace GuvenOto.Models
{
    public class IlanOzellikDegeri
    {
        [Key]
        public int Id { get; set; }

        // Ilan tablosu ile ilişkiyi netleştiriyoruz
        public int IlanId { get; set; }

        [ForeignKey("IlanId")] // Bu satır kesin çözüm için kritik
        public virtual Ilan? Ilan { get; set; }

        // Ozellik tablosu ile ilişkiyi netleştiriyoruz
        public int OzellikId { get; set; }

        [ForeignKey("OzellikId")] // Bu satır kesin çözüm için kritik
        public virtual Ozellik? Ozellik { get; set; }

        public string? Value { get; set; }
    }
}

