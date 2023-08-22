﻿// <auto-generated />
using System;
using ExtraaEdgeAssignment.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExtraaEdgeAssignment.Migrations
{
    [DbContext(typeof(MobileDbContext))]
    partial class MobileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ExtraaEdgeAssignment.Models.Mobile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MobileBrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumberOfMobiles")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MobileBrandId");

                    b.ToTable("Mobiles");
                });

            modelBuilder.Entity("ExtraaEdgeAssignment.Models.MobileBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MobileBrands");
                });

            modelBuilder.Entity("ExtraaEdgeAssignment.Models.MobileSales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MobileId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfMobileSales")
                        .HasColumnType("int");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MobileId");

                    b.ToTable("MobileSales");
                });

            modelBuilder.Entity("ExtraaEdgeAssignment.Models.Mobile", b =>
                {
                    b.HasOne("ExtraaEdgeAssignment.Models.MobileBrand", "MobileBrand")
                        .WithMany("MobileId")
                        .HasForeignKey("MobileBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MobileBrand");
                });

            modelBuilder.Entity("ExtraaEdgeAssignment.Models.MobileSales", b =>
                {
                    b.HasOne("ExtraaEdgeAssignment.Models.Mobile", "Mob")
                        .WithMany("MobilesId")
                        .HasForeignKey("MobileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mob");
                });

            modelBuilder.Entity("ExtraaEdgeAssignment.Models.Mobile", b =>
                {
                    b.Navigation("MobilesId");
                });

            modelBuilder.Entity("ExtraaEdgeAssignment.Models.MobileBrand", b =>
                {
                    b.Navigation("MobileId");
                });
#pragma warning restore 612, 618
        }
    }
}
