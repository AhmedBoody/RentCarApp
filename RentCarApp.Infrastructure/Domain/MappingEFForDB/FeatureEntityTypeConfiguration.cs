
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentCarApp.Domain.Cities;
using RentCarApp.Domain.Features;
using RentCarApp.Infrastructure.Database;

namespace RentCarApp.Infrastructure.Domain.MappingEFForDB
{
    internal sealed class FeatureEntityTypeConfiguration : IEntityTypeConfiguration<Feature>
    {

        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.ToTable("Features", SchemaNames.Lookups);

            builder.HasKey(b => b.Id);

            builder.Property("nameEn").HasColumnName("NameEn");
            builder.Property("nameAr").HasColumnName("NameAr");


        }
    }
}