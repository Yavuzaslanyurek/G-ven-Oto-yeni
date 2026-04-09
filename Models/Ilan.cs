using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuvenOto.Models
{
    public class Ilan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "İlan başlığı zorunludur.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Plaka alanı zorunludur.")]
        [Display(Name = "Plaka")]
        public string Plate { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Year { get; set; }

        public int Kilometer { get; set; }

        public int AracModeliId { get; set; }

        [ForeignKey("AracModeliId")]
        public virtual AracModeli? AracModeli { get; set; }

        // Ekspertiz Durumları
        public int HoodStatus { get; set; } = 0;
        public int RoofStatus { get; set; } = 0;
        public int TrunkStatus { get; set; } = 0;
        public int FrontBumperStatus { get; set; } = 0;
        public int RearBumperStatus { get; set; } = 0;
        public int FrontLeftFender { get; set; } = 0;
        public int FrontLeftDoor { get; set; } = 0;
        public int RearLeftDoor { get; set; } = 0;
        public int RearLeftFender { get; set; } = 0;
        public int FrontRightFender { get; set; } = 0;
        public int FrontRightDoor { get; set; } = 0;
        public int RearRightDoor { get; set; } = 0;
        public int RearRightFender { get; set; } = 0;

        public int CityId { get; set; }
        public virtual Sehir? Sehir { get; set; }

        public int DistrictId { get; set; }
        public virtual Ilce? Ilce { get; set; }

        public string? ExpertisePdfPath { get; set; }
        public string? MainImageUrl { get; set; }

        // Sadece mevcut olanı bırakıyoruz (Hataları önlemek için)
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public virtual ICollection<IlanOzellikDegeri> IlanOzellikDegeri { get; set; } = new HashSet<IlanOzellikDegeri>();
    }
}



