
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Cars.ValueObjects;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.SharedKernel;
using RentCarApp.Infrastructure.Database;
using System;

namespace RentCarApp.Infrastructure.Domain.MappingEFForDB
{
    internal sealed class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {

        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars", SchemaNames.Lookups);
            
            builder.HasKey(b => b.Id);

            builder.Property<Guid>("CarModelId").HasColumnName("CarModelId");
            builder.HasOne<CarModel>().WithMany().HasForeignKey("CarModelId");

            builder.Property<Guid>("CarTypelId").HasColumnName("CarTypelId");
            builder.HasOne<CarType>().WithMany().HasForeignKey("CarTypelId");


            builder.OwnsOne<MoneyValue>("DailyRent", y =>
            {
                y.Property(p => p.Currency).HasColumnName("CurrencyForDailyRent");
                y.Property(p => p.Value).HasColumnName("ValueForDailyRent");
            });

            builder.OwnsOne<MoneyValue>("WeeklyRent", y =>
            {
                y.Property(p => p.Currency).HasColumnName("CurrencyForWeeklyRent");
                y.Property(p => p.Value).HasColumnName("ValueForWeeklyRent");
            });

            builder.OwnsOne<PlateNumberValue>("PlateNumber", y =>
            {
                y.Property(p => p.PlateNumber).HasColumnName("PlateNumber");
            });

            builder.OwnsOne<ModelYearValue>("ModelYear", y =>
            {
                y.Property(p => p.Year).HasColumnName("ModelYear");
            });

            builder.OwnsMany<CarFeature>("CarFeatures", Y=> {

                Y.ToTable("CarFeatures", SchemaNames.Lookups);
                
                Y.HasKey("CarId", "FeatureId");

                Y.WithOwner().HasForeignKey("CarId");

                Y.Property<Guid>("CarId");
                Y.Property<Guid>("FeatureId");

            });

        }
    }
}