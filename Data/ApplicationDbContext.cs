using Microsoft.EntityFrameworkCore;
using GuvenOto.Models;
using System;

namespace GuvenOto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // --- TEMEL TABLOLAR ---
        public DbSet<Kullanici> Users { get; set; }
        public DbSet<Araba> Arabalar { get; set; }
        public DbSet<Ozellik> Ozellikler { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<AracModeli> Models { get; set; }
        public DbSet<Ilan> Ilanlar { get; set; }
        public DbSet<IlanOzellikDegeri> ılanOzellikDegeri { get; set; }

        // --- SORGULAMA SİSTEMİ TABLOLARI ---
        public DbSet<AracRuhsat> AracRuhsatlari { get; set; }
        public DbSet<AracMuayene> AracMuayeneleri { get; set; }
        public DbSet<AracHasarKaydi> AracHasarKayitlari { get; set; }

        // --- LOKASYON SİSTEMİ TABLOLARI ---
        public DbSet<Bolge> Bolgeler { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- 1. TABLO EŞLEMELERİ (TABLE MAPPING) ---
            modelBuilder.Entity<Marka>().ToTable("Brands");
            modelBuilder.Entity<AracModeli>().ToTable("Models");
            modelBuilder.Entity<Ilan>().ToTable("Listings");
            modelBuilder.Entity<Araba>().ToTable("Cars");
            modelBuilder.Entity<Sehir>().ToTable("Cities");
            modelBuilder.Entity<Ilce>().ToTable("Districts");
            modelBuilder.Entity<Bolge>().ToTable("Regions");
            modelBuilder.Entity<Ozellik>().ToTable("Features");
            modelBuilder.Entity<Kullanici>().ToTable("Users");
            modelBuilder.Entity<IlanOzellikDegeri>().ToTable("ListingFeatureValues");
            modelBuilder.Entity<AracHasarKaydi>().ToTable("VehicleDamageRecords");
            modelBuilder.Entity<AracMuayene>().ToTable("VehicleInspections");
            modelBuilder.Entity<AracRuhsat>().ToTable("VehicleRegistries");

            // --- 2. SÜTUN VE İLİŞKİ EŞLEMELERİ ---

            // Sehir (Cities) Tablosu
            modelBuilder.Entity<Sehir>(entity =>
            {
                entity.Property(e => e.RegionId).HasColumnName("RegionId");
                entity.HasOne(s => s.Bolge)
                      .WithMany(b => b.Sehirler)
                      .HasForeignKey(s => s.RegionId);
            });

            // Ilce (Districts) Tablosu
            modelBuilder.Entity<Ilce>(entity =>
            {
                entity.Property(e => e.CityId).HasColumnName("CityId");
                entity.HasOne(i => i.Sehir)
                      .WithMany(s => s.Ilceler)
                      .HasForeignKey(i => i.CityId);
            });

            // Ilan (Listings) Tablosu - KRİTİK DÜZENLEME
            modelBuilder.Entity<Ilan>(entity =>
            {
                entity.Property(e => e.AracModeliId).HasColumnName("ModelId");
                entity.Property(e => e.CityId).HasColumnName("CityId");
                entity.Property(e => e.DistrictId).HasColumnName("DistrictId");

                // Aldığın 1785 numaralı hatayı çözen kısım burası:
                entity.HasOne(l => l.AracModeli)
                      .WithMany(m => m.Ilanlar)
                      .HasForeignKey(l => l.AracModeliId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(l => l.Sehir)
                      .WithMany()
                      .HasForeignKey(l => l.CityId)
                      .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(l => l.Ilce)
                      .WithMany()
                      .HasForeignKey(l => l.DistrictId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            // Araba (Cars) Tablosu
            modelBuilder.Entity<Araba>(entity =>
            {
                entity.Property(e => e.AracModeliId).HasColumnName("ModelId");
                entity.Property(e => e.MarkaId).HasColumnName("BrandId");

                // Buradaki Cascade silmeyi de kapatıyoruz (Döngü oluşmaması için)
                entity.HasOne(a => a.AracModeli)
                      .WithMany()
                      .HasForeignKey(a => a.AracModeliId)
                      .OnDelete(DeleteBehavior.NoAction);
            });

            // AracModeli (Models) Tablosu
            modelBuilder.Entity<AracModeli>(entity =>
            {
                entity.Property(e => e.MarkaId).HasColumnName("BrandId");
            });

            // --- 4. SEED DATA ---
            modelBuilder.Entity<AracRuhsat>().HasData(
                new AracRuhsat { Id = 1, Plate = "57ED244", EngineNumber = "MOTOR-ED-1122", ChassisNumber = "SASI-ED-9988", OwnerName = "Ahmet Yılmaz", VehicleColor = "Beyaz", RegistrationDate = new DateTime(2015, 5, 10) },
                new AracRuhsat { Id = 2, Plate = "57AAR642", EngineNumber = "MOTOR-AA-5544", ChassisNumber = "SASI-AA-3322", OwnerName = "Mehmet Demir", VehicleColor = "Metalik Gri", RegistrationDate = new DateTime(2020, 11, 20) }
            );

            modelBuilder.Entity<AracMuayene>().HasData(
                new AracMuayene { Id = 1, Plate = "57ED244", InspectionDate = new DateTime(2021, 6, 15), KilometerAtInspection = 185000, InspectionStation = "Sinop Merkez" },
                new AracMuayene { Id = 2, Plate = "57ED244", InspectionDate = new DateTime(2023, 6, 20), KilometerAtInspection = 240000, InspectionStation = "Sinop Boyabat" }
            );

            modelBuilder.Entity<AracHasarKaydi>().HasData(
                new AracHasarKaydi { Id = 1, Plate = "57ED244", DamageDate = new DateTime(2019, 3, 12), Amount = 12500, IsHeavyDamage = false, DamageReason = "Carpisma hasari." },
                new AracHasarKaydi { Id = 2, Plate = "57ED244", DamageDate = new DateTime(2022, 10, 5), Amount = 85000, IsHeavyDamage = true, DamageReason = "Agir Hasar kaydi." }
            );
        }
    }
}

