
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Manufacturers;
using RentCarApp.Infrastructure.Database;

namespace RentCarApp.Infrastructure.Domain.MappingEFForDB
{
    internal sealed class ManufactureEntityTypeConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.ToTable("Manufacturers", SchemaNames.Lookups);
            
            builder.HasKey(b => b.Id);

            builder.Property("nameEn").HasColumnName("NameEn");
            builder.Property("nameAr").HasColumnName("NameAr");
            

        }
    }
}