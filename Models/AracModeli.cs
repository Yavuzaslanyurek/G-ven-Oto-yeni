using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuvenOto.Models
{
    public class AracModeli
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "AracModeli adı boş bırakılamaz.")]
        [Display(Name = "Model / Paket Adı")]
        public string Name { get; set; } // Örn: Focus, 1.6 TDCi veya Titanium

        // --- MARKA İLİŞKİSİ ---
        [Required]
        public int MarkaId { get; set; }
        public Marka Marka { get; set; }

        // --- HİYERARŞİK (ALT MODEL) İLİŞKİSİ ---

        // Eğer bu bir üst modelse (Örn: Focus), ParentModelId null olur.
        // Eğer bu bir alt seçenekse (Örn: Titanium), ParentModelId "Focus"un Id'si olur.
        [Display(Name = "Üst Seçenek")]
        public int? ParentModelId { get; set; }

        [ForeignKey("ParentModelId")]
        public AracModeli? ParentModel { get; set; }

        // Bu modele bağlı alt seçeneklerin listesi (Örn: Focus'un altındaki paketler)
        public ICollection<AracModeli> SubModels { get; set; } = new List<AracModeli>();

        public virtual ICollection<Ilan> Ilanlar { get; set; } = new HashSet<Ilan>();
    }
}

