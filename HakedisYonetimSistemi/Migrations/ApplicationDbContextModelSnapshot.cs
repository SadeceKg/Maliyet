﻿// <auto-generated />
using System;
using HakedisYonetimSistemi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HakedisYonetimSistemi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("HakedisYonetimSistemi.Models.Hakedis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DonemBaslangic")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DonemBitis")
                        .HasColumnType("TEXT");

                    b.Property<int>("Durum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HakedisNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HakedisTarihi")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("HakedisTutari")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("KdvOrani")
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime?>("OdemeTarihi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("OnayTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjeId");

                    b.ToTable("Hakedisler");
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.HakedisDetay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("BirimFiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HakedisId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaliyetKalemiId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Miktar")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("HakedisId");

                    b.HasIndex("MaliyetKalemiId");

                    b.ToTable("HakedisDetaylari");
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.MaliyetKalemi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Aktif")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Birim")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("BirimFiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("KalemAdi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("Kategori")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjeId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("ToplamMiktar")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("ProjeId");

                    b.ToTable("MaliyetKalemleri");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aciklama = "Hazır beton C25",
                            Aktif = true,
                            Birim = "m³",
                            BirimFiyat = 450m,
                            KalemAdi = "Beton C25",
                            Kategori = 0,
                            OlusturulmaTarihi = new DateTime(2025, 6, 25, 9, 59, 37, 530, DateTimeKind.Local).AddTicks(5793),
                            ProjeId = 1,
                            ToplamMiktar = 500m
                        },
                        new
                        {
                            Id = 2,
                            Aciklama = "Betonarme demir işçiliği",
                            Aktif = true,
                            Birim = "kg",
                            BirimFiyat = 8m,
                            KalemAdi = "Demir İşçiliği",
                            Kategori = 1,
                            OlusturulmaTarihi = new DateTime(2025, 6, 25, 9, 59, 37, 530, DateTimeKind.Local).AddTicks(5796),
                            ProjeId = 1,
                            ToplamMiktar = 15000m
                        },
                        new
                        {
                            Id = 3,
                            Aciklama = "19 cm tuğla duvar",
                            Aktif = true,
                            Birim = "m²",
                            BirimFiyat = 85m,
                            KalemAdi = "Tuğla Duvar",
                            Kategori = 0,
                            OlusturulmaTarihi = new DateTime(2025, 6, 25, 9, 59, 37, 530, DateTimeKind.Local).AddTicks(5799),
                            ProjeId = 1,
                            ToplamMiktar = 2000m
                        });
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.Proje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Adres")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("BitisTarihi")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Butce")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Durum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MusteriAdi")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OlusturulmaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjeAdi")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projeler");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aciklama = "Konut inşaat projesi",
                            BaslangicTarihi = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BitisTarihi = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Butce = 1000000m,
                            Durum = 0,
                            MusteriAdi = "ABC İnşaat Ltd. Şti.",
                            OlusturulmaTarihi = new DateTime(2025, 6, 25, 9, 59, 37, 530, DateTimeKind.Local).AddTicks(5613),
                            ProjeAdi = "Örnek İnşaat Projesi"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.Hakedis", b =>
                {
                    b.HasOne("HakedisYonetimSistemi.Models.Proje", "Proje")
                        .WithMany("Hakedisler")
                        .HasForeignKey("ProjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proje");
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.HakedisDetay", b =>
                {
                    b.HasOne("HakedisYonetimSistemi.Models.Hakedis", "Hakedis")
                        .WithMany("HakedisDetaylari")
                        .HasForeignKey("HakedisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HakedisYonetimSistemi.Models.MaliyetKalemi", "MaliyetKalemi")
                        .WithMany("HakedisDetaylari")
                        .HasForeignKey("MaliyetKalemiId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Hakedis");

                    b.Navigation("MaliyetKalemi");
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.MaliyetKalemi", b =>
                {
                    b.HasOne("HakedisYonetimSistemi.Models.Proje", "Proje")
                        .WithMany("MaliyetKalemleri")
                        .HasForeignKey("ProjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proje");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.Hakedis", b =>
                {
                    b.Navigation("HakedisDetaylari");
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.MaliyetKalemi", b =>
                {
                    b.Navigation("HakedisDetaylari");
                });

            modelBuilder.Entity("HakedisYonetimSistemi.Models.Proje", b =>
                {
                    b.Navigation("Hakedisler");

                    b.Navigation("MaliyetKalemleri");
                });
#pragma warning restore 612, 618
        }
    }
}
