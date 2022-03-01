
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Cities;
using RentCarApp.Infrastructure.Database;

namespace RentCarApp.Infrastructure.Domain.MappingEFForDB
{
    internal sealed class CityEntityTypeConfiguration : IEntityTypeConfiguration<City>
    {
        
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities", SchemaNames.Lookups);
            
            builder.HasKey(b => b.Id);

            builder.Property("nameEn").HasColumnName("NameEn");
            builder.Property("nameAr").HasColumnName("NameAr");
            

        }
    }
}