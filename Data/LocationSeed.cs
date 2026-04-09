using GuvenOto.Models;
using Microsoft.EntityFrameworkCore;

namespace GuvenOto.Data
{
    public static class LocationSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // 1. BÖLGELER (Tam Liste)
            modelBuilder.Entity<Bolge>().HasData(
                new Bolge { Id = 1, Name = "Marmara" },
                new Bolge { Id = 2, Name = "İç Anadolu" },
                new Bolge { Id = 3, Name = "Ege" },
                new Bolge { Id = 4, Name = "Akdeniz" },
                new Bolge { Id = 5, Name = "Karadeniz" },
                new Bolge { Id = 6, Name = "Güneydoğu Anadolu" },
                new Bolge { Id = 7, Name = "Doğu Anadolu" }
            );

            // 2. İLLER (81 İl - Örnek Başlangıç, Buraya 81'e kadar ekleme yapabilirsin)
            modelBuilder.Entity<Sehir>().HasData(
                new Sehir { Id = 1, Name = "Adana", RegionId = 4 },
                new Sehir { Id = 6, Name = "Ankara", RegionId = 2 },
                new Sehir { Id = 34, Name = "İstanbul", RegionId = 1 },
                new Sehir { Id = 35, Name = "İzmir", RegionId = 3 },
                new Sehir { Id = 55, Name = "Samsun", RegionId = 5 },
                new Sehir { Id = 57, Name = "Sinop", RegionId = 5 }
                // ... Buraya diğer illeri ID ve Plaka koduna göre ekleyebilirsin
            );

            // 3. İLÇELER (Tüm Türkiye Listesi Çok Uzundur, SQL ile basmak daha sağlıklıdır)
            modelBuilder.Entity<Ilce>().HasData(
                new Ilce { Id = 1, Name = "Seyhan", CityId = 1 },
                new Ilce { Id = 2, Name = "Çankaya", CityId = 6 },
                new Ilce { Id = 3, Name = "Kadıköy", CityId = 34 },
                new Ilce { Id = 4, Name = "Beşiktaş", CityId = 34 },
                new Ilce { Id = 5, Name = "İlkadım", CityId = 55 },
                new Ilce { Id = 6, Name = "Boyabat", CityId = 57 }
            );
        }
    }
}
