﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCarApp.Infrastructure.Database;

namespace RentCarApp.Infrastructure.Migrations
{
    [DbContext(typeof(RentCarContext))]
    partial class RentCarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentCarApp.Domain.Cities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarModelId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CarModelId");

                    b.Property<Guid>("CarTypelId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CarTypelId");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("CarTypelId");

                    b.ToTable("Cars", "lookups");
                });

            modelBuilder.Entity("RentCarApp.Domain.Cities.CarModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CarCounter")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("manufactureId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ManufactureId");

                    b.Property<string>("nameAr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameAr");

                    b.Property<string>("nameEn")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameEn");

                    b.HasKey("Id");

                    b.HasIndex("manufactureId");

                    b.ToTable("CarModels", "lookups");
                });

            modelBuilder.Entity("RentCarApp.Domain.Cities.CarType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("nameAr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameAr");

                    b.Property<string>("nameEn")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameEn");

                    b.HasKey("Id");

                    b.ToTable("CarTypes", "lookups");
                });

            modelBuilder.Entity("RentCarApp.Domain.Cities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("nameAr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameAr");

                    b.Property<string>("nameEn")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameEn");

                    b.HasKey("Id");

                    b.ToTable("Cities", "lookups");
                });

            modelBuilder.Entity("RentCarApp.Domain.Features.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("nameAr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameAr");

                    b.Property<string>("nameEn")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameEn");

                    b.HasKey("Id");

                    b.ToTable("Features", "lookups");
                });

            modelBuilder.Entity("RentCarApp.Domain.Manufacturers.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("nameAr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameAr");

                    b.Property<string>("nameEn")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameEn");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers", "lookups");
                });

            modelBuilder.Entity("RentCarApp.Infrastructure.Processing.InternalCommands.InternalCommand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InternalCommands", "app");
                });

            modelBuilder.Entity("RentCarApp.Infrastructure.Processing.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OccurredOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ProcessedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OutboxMessages", "app");
                });

            modelBuilder.Entity("RentCarApp.Domain.Cities.Car", b =>
                {
                    b.HasOne("RentCarApp.Domain.Cities.CarModel", null)
                        .WithMany()
                        .HasForeignKey("CarModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentCarApp.Domain.Cities.CarType", null)
                        .WithMany()
                        .HasForeignKey("CarTypelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RentCarApp.Domain.Cars.ValueObjects.ModelYearValue", "ModelYear", b1 =>
                        {
                            b1.Property<Guid>("CarId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Year")
                                .HasColumnType("int")
                                .HasColumnName("ModelYear");

                            b1.HasKey("CarId");

                            b1.ToTable("Cars");

                            b1.WithOwner()
                                .HasForeignKey("CarId");
                        });

                    b.OwnsOne("RentCarApp.Domain.Cars.ValueObjects.PlateNumberValue", "PlateNumber", b1 =>
                        {
                            b1.Property<Guid>("CarId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PlateNumber")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PlateNumber");

                            b1.HasKey("CarId");

                            b1.ToTable("Cars");

                            b1.WithOwner()
                                .HasForeignKey("CarId");
                        });

                    b.OwnsMany("RentCarApp.Domain.Cities.CarFeature", "CarFeatures", b1 =>
                        {
                            b1.Property<Guid>("CarId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("FeatureId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<bool>("IsDeleted")
                                .HasColumnType("bit");

                            b1.HasKey("CarId", "FeatureId");

                            b1.ToTable("CarFeatures", "lookups");

                            b1.WithOwner()
                                .HasForeignKey("CarId");
                        });

                    b.OwnsOne("RentCarApp.Domain.SharedKernel.MoneyValue", "DailyRent", b1 =>
                        {
                            b1.Property<Guid>("CarId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CurrencyForDailyRent");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("ValueForDailyRent");

                            b1.HasKey("CarId");

                            b1.ToTable("Cars");

                            b1.WithOwner()
                                .HasForeignKey("CarId");
                        });

                    b.OwnsOne("RentCarApp.Domain.SharedKernel.MoneyValue", "WeeklyRent", b1 =>
                        {
                            b1.Property<Guid>("CarId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Currency")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CurrencyForWeeklyRent");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("ValueForWeeklyRent");

                            b1.HasKey("CarId");

                            b1.ToTable("Cars");

                            b1.WithOwner()
                                .HasForeignKey("CarId");
                        });

                    b.Navigation("CarFeatures");

                    b.Navigation("DailyRent");

                    b.Navigation("ModelYear");

                    b.Navigation("PlateNumber");

                    b.Navigation("WeeklyRent");
                });

            modelBuilder.Entity("RentCarApp.Domain.Cities.CarModel", b =>
                {
                    b.HasOne("RentCarApp.Domain.Manufacturers.Manufacturer", "Manufacturer")
                        .WithMany("CarModels")
                        .HasForeignKey("manufactureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("RentCarApp.Domain.Manufacturers.Manufacturer", b =>
                {
                    b.Navigation("CarModels");
                });
#pragma warning restore 612, 618
        }
    }
}
