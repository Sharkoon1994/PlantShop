using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantShop.Data.Entities;

namespace PlantShop.Data.EntityConfiguration
{
    [ExcludeFromCodeCoverage]
    public class PlantShopEntityConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("Plant");
            builder.Property(x => x.Name).IsRequired().IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.Description).IsUnicode(false).HasMaxLength(255);
            builder.HasIndex(p => p.Name).IsUnique();
        }
    }
}