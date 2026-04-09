using System.ComponentModel.DataAnnotations;

namespace GuvenOto.Models
{
    public class Ozellik
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Özellik adı boş bırakılamaz.")]
        [Display(Name = "Özellik Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kategori seçilmelidir.")]
        [Display(Name = "Kategori")]
        public FeatureCategory Category { get; set; }

        [Required(ErrorMessage = "Giriş tipi seçilmelidir.")]
        [Display(Name = "Giriş Tipi")]
        public FeatureType InputType { get; set; }

        // --- DINAMIK KISITLAMA ALANLARI ---

        [Display(Name = "Seçenekler (Virgülle ayırın)")]
        public string? Options { get; set; } // Dropdown seçilirse: "Benzin, Dizel, Hibrit"

        [Display(Name = "Maksimum Uzunluk / Sınır")]
        public int? MaxLength { get; set; } // Örn: Yıl için 4, KM için 7 karakter

        [Display(Name = "Birim / Format")]
        public string? FormatType { get; set; } // Örn: "km", "hp", "cc" veya "Numeric"
    }

    public enum FeatureCategory
    {
        [Display(Name = "Genel Özellikler")]
        General = 1,
        [Display(Name = "Güvenlik")]
        Security = 2,
        [Display(Name = "İç Donanım")]
        Interior = 3,
        [Display(Name = "Dış Donanım")]
        Exterior = 4
    }

    public enum FeatureType
    {
        [Display(Name = "Evet/Hayır (Checkbox)")]
        Checkbox = 1,
        [Display(Name = "Metin (Text)")]
        Text = 2,
        [Display(Name = "Sayı (Number)")]
        Number = 3,
        [Display(Name = "Liste (Dropdown)")]
        Dropdown = 4
    }
}
