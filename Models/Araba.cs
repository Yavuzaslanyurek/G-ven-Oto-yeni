using System;

namespace GuvenOto.Models
{
    public class Araba
    {
        public int Id { get; set; }

        public string Title { get; set; } // İlan Başlığı
        public string Description { get; set; } // Açıklama

        public int Year { get; set; } // Yıl
        public int Kilometer { get; set; } // KM
        public decimal Price { get; set; } // Fiyat

        // İlişkiler
        public int MarkaId { get; set; }
        public Marka Marka { get; set; }

        public int AracModeliId { get; set; }
        public AracModeli Model { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual AracModeli AracModeli { get; set; }
    }
}


