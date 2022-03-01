
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Cities;
using RentCarApp.Infrastructure.Database;

namespace RentCarApp.Infrastructure.Domain.MappingEFForDB
{
    internal sealed class CarModelEntityTypeConfiguration : IEntityTypeConfiguration<CarModel>
    {

        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.ToTable("CarModels", SchemaNames.Lookups);
            builder.HasOne(x => x.Manufacturer)
                .WithMany(w => w.CarModels)
                .HasForeignKey(x => x.manufactureId);

            builder.HasKey(b => b.Id);
            builder.Property("nameEn").HasColumnName("NameEn");
            builder.Property("nameAr").HasColumnName("NameAr");
            builder.Property("manufactureId").HasColumnName("ManufactureId");


        }
    }
}