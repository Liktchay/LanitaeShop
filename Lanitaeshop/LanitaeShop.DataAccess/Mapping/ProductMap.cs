using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LanitaeShop.DomainModel;

namespace LanitaeShop.DataAccess.Mapping
{

    internal class ProductMap : IEntityTypeConfiguration<Product>
    {

        
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(pd => pd.ID)
                   .HasColumnName("ID")
                   .HasColumnType("int")
                   .ValueGeneratedOnAdd()
                   .IsRequired(true);

            builder.HasKey(pd => pd.ID);

            builder.Property(pd => pd.ProductName)
                   .HasColumnName("Product_Name")
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(true);

            builder.Property(pd => pd.ProductDescription)
                   .HasColumnName("Product_Description")
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(pd => pd.ProductPrice)
                   .HasColumnName("Product_Price")
                   .HasColumnType("int")
                   .HasDefaultValue(200)
                   .IsRequired(true);

            builder.Property(pd => pd.ProductStock)
                   .HasColumnName("Product_Stock")
                   .HasColumnType("int")
                   .IsRequired(true);

            builder.Property(pd => pd.ProductEnable)
                   .HasColumnName("Product_Enable")
                   .HasColumnType("bit")
                   .IsRequired(true);

            builder.Property(pd => pd.ImageSource)
                   .HasColumnName("Image_Source")
                   .HasColumnType("nvarchar")
                   .IsRequired(false);

            builder.HasMany<Sale>(pr => pr.Sale)
                   .WithOne(sl => sl.Product)
                   .HasForeignKey(sl => sl.ProductID)
                   .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
