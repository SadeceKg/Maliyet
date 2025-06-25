using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HakedisYonetimSistemi.Models;

namespace HakedisYonetimSistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Proje> Projeler { get; set; }
        public DbSet<Hakedis> Hakedisler { get; set; }
        public DbSet<HakedisDetay> HakedisDetaylari { get; set; }
        public DbSet<MaliyetKalemi> MaliyetKalemleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Proje konfigürasyonu
            modelBuilder.Entity<Proje>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProjeAdi).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Butce).HasColumnType("decimal(18,2)");
                entity.Property(e => e.MusteriAdi).HasMaxLength(200);
                entity.Property(e => e.Aciklama).HasMaxLength(1000);
            });

            // Hakediş konfigürasyonu
            modelBuilder.Entity<Hakedis>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.HakedisNo).IsRequired().HasMaxLength(50);
                entity.Property(e => e.HakedisTutari).HasColumnType("decimal(18,2)");
                entity.Property(e => e.KdvOrani).HasColumnType("decimal(5,2)");
                entity.Property(e => e.Aciklama).HasMaxLength(1000);
                
                entity.HasOne(e => e.Proje)
                    .WithMany(p => p.Hakedisler)
                    .HasForeignKey(e => e.ProjeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Maliyet Kalemi konfigürasyonu
            modelBuilder.Entity<MaliyetKalemi>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.KalemAdi).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Birim).IsRequired().HasMaxLength(50);
                entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18,2)");
                entity.Property(e => e.ToplamMiktar).HasColumnType("decimal(18,3)");
                entity.Property(e => e.Aciklama).HasMaxLength(1000);
                
                entity.HasOne(e => e.Proje)
                    .WithMany(p => p.MaliyetKalemleri)
                    .HasForeignKey(e => e.ProjeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Hakediş Detay konfigürasyonu
            modelBuilder.Entity<HakedisDetay>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Miktar).HasColumnType("decimal(18,3)");
                entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Aciklama).HasMaxLength(500);
                
                entity.HasOne(e => e.Hakedis)
                    .WithMany(h => h.HakedisDetaylari)
                    .HasForeignKey(e => e.HakedisId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                entity.HasOne(e => e.MaliyetKalemi)
                    .WithMany(m => m.HakedisDetaylari)
                    .HasForeignKey(e => e.MaliyetKalemiId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Örnek proje
            modelBuilder.Entity<Proje>().HasData(
                new Proje
                {
                    Id = 1,
                    ProjeAdi = "Örnek İnşaat Projesi",
                    Aciklama = "Konut inşaat projesi",
                    BaslangicTarihi = new DateTime(2024, 1, 1),
                    BitisTarihi = new DateTime(2024, 12, 31),
                    Butce = 1000000m,
                    MusteriAdi = "ABC İnşaat Ltd. Şti.",
                    Durum = ProjeDurum.Aktif,
                    OlusturulmaTarihi = DateTime.Now
                }
            );

            // Örnek maliyet kalemleri
            modelBuilder.Entity<MaliyetKalemi>().HasData(
                new MaliyetKalemi
                {
                    Id = 1,
                    ProjeId = 1,
                    KalemAdi = "Beton C25",
                    Aciklama = "Hazır beton C25",
                    Birim = "m³",
                    BirimFiyat = 450m,
                    ToplamMiktar = 500m,
                    Kategori = MaliyetKategori.Malzeme,
                    Aktif = true,
                    OlusturulmaTarihi = DateTime.Now
                },
                new MaliyetKalemi
                {
                    Id = 2,
                    ProjeId = 1,
                    KalemAdi = "Demir İşçiliği",
                    Aciklama = "Betonarme demir işçiliği",
                    Birim = "kg",
                    BirimFiyat = 8m,
                    ToplamMiktar = 15000m,
                    Kategori = MaliyetKategori.Iscilik,
                    Aktif = true,
                    OlusturulmaTarihi = DateTime.Now
                },
                new MaliyetKalemi
                {
                    Id = 3,
                    ProjeId = 1,
                    KalemAdi = "Tuğla Duvar",
                    Aciklama = "19 cm tuğla duvar",
                    Birim = "m²",
                    BirimFiyat = 85m,
                    ToplamMiktar = 2000m,
                    Kategori = MaliyetKategori.Malzeme,
                    Aktif = true,
                    OlusturulmaTarihi = DateTime.Now
                }
            );
        }
    }
}