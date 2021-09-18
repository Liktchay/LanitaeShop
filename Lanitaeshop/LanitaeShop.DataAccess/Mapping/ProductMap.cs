using Microsoft.EntityFrameworkCore;
using LanitaeShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanitaeShop.DataAccess.Mapping
{

    internal class ProductMap : IEntityTypeConfiguration<Entities.Product>
    {

        
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder//.Entity<Product>()
                   .ToTable("Product");

            builder//.Entity<Product>()
                   .Property(pd => pd.ID)
                   .HasColumnName("ID")
                   .HasColumnType("int")
                   .ValueGeneratedOnAdd()
                   .IsRequired(true);

            builder//.Entity<Product>()
                   .HasKey(pd => pd.ID);

            builder//.Entity<Product>()
                   .Property(pd => pd.Garment)
                   .HasColumnName("Garment")
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(true);

            builder//.Entity<Product>()
                   .Property(pd => pd.Price)
                   .HasColumnName("Price")
                   .HasColumnType("decimal")
                   .HasPrecision(10, 3)
                   .IsRequired(true);

            builder//.Entity<Product>()
                   .HasMany<ProductVariety>(pv => pv.ProductVariety)
                   .WithOne(pd => pd.Product)
                   .HasForeignKey(pv => pv.ProductID)
                   .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
