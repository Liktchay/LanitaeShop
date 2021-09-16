using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LanitaeShop.DataAccess.Entities;

namespace LanitaeShop.DataAccess.Mapping
{
    internal class ProductVarietyMap
    {
        public void Configure(ModelBuilder builder)
        {
            builder.Entity<ProductVariety>().ToTable("Product_Variety");

            builder.Entity<ProductVariety>()
                   .Property(pv => pv.ID)
                   .HasColumnName("ID")
                   .HasColumnType("int")
                   .ValueGeneratedOnAdd()
                   .IsRequired(true);

            builder.Entity<ProductVariety>()
                   .HasKey(pv => pv.ID);

            builder.Entity<ProductVariety>()
                   .Property(pv => pv.ProductID)
                   .HasColumnName("Product_ID")
                   .HasColumnType("int")
                   .IsRequired(true);

            builder.Entity<ProductVariety>()
                   .Property(pv => pv.ProductDescription)
                   .HasColumnName("Product_Description")
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(true);

            builder.Entity<ProductVariety>()
                   .Property(pv => pv.Color)
                   .HasColumnName("Color")
                   .HasColumnType("varchar")
                   .HasMaxLength(200)
                   .IsRequired(true);

            builder.Entity<ProductVariety>()
                   .Property(pv => pv.Stock)
                   .HasColumnName("Stock")
                   .HasColumnType("int")
                   .IsRequired(true);

            builder.Entity<ProductVariety>()
                   .HasOne<Product>(pd => pd.Product)
                   .WithMany(pv => pv.ProductVariety)
                   .HasForeignKey(pd => pd.ID)
                   .OnDelete(DeleteBehavior.NoAction);


        }


    }
}
