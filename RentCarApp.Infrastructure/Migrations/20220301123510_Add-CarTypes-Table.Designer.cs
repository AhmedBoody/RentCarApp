﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentCarApp.Infrastructure.Database;

namespace RentCarApp.Infrastructure.Migrations
{
    [DbContext(typeof(RentCarContext))]
    [Migration("20220301123510_Add-CarTypes-Table")]
    partial class AddCarTypesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
#pragma warning restore 612, 618
        }
    }
}
