using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopOnWeb.ApplicationCore.Enities;

namespace Infrastructure.Data.Config
{
    public class CatalogTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Id)
                .UseHiLo("catalog_type_id")
                .IsRequired();

            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(100);
                
        }
    }
}
