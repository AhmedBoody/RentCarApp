
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Cities;
using RentCarApp.Infrastructure.Database;

namespace RentCarApp.Infrastructure.Domain.MappingEFForDB
{
    internal sealed class CarTypeEntityTypeConfiguration : IEntityTypeConfiguration<CarType>
    {

        public void Configure(EntityTypeBuilder<CarType> builder)
        {
            builder.ToTable("CarTypes", SchemaNames.Lookups);

            builder.HasKey(b => b.Id);

            builder.Property("nameEn").HasColumnName("NameEn");
            builder.Property("nameAr").HasColumnName("NameAr");


        }
    }
}