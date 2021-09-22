using System.Data;
using Microsoft.EntityFrameworkCore;
using LanitaeShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LanitaeShop.DataAccess.Mapping
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");

            builder.Property(sl => sl.ID)
                   .HasColumnName("ID")
                   .HasColumnType("int")
                   .ValueGeneratedOnAdd()
                   .IsRequired(true);

            builder.HasKey(sl => sl.ID);

            builder.HasOne<Product>(sl => sl.Product)
                   .WithMany(pd => pd.Sale)
                   .HasForeignKey(sl => sl.ProductID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(sl => sl.SaleTotalAmount)
                   .HasColumnName("Sale_Total_Amount")
                   .HasColumnType("int")
                   .IsRequired(true);

            builder.HasOne<Person>(sl => sl.Person)
                   .WithMany(pr => pr.Sale)
                   .HasForeignKey(sl => sl.PersonID)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(sl => sl.SaleDate)
                   .HasColumnName("Sale_Date")
                   .HasColumnType("datetime")
                   .ValueGeneratedOnAdd()
                   .IsRequired(true);
        }

    }
}
