using JuanApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanApp.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x=>x.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()");
            builder.HasMany(p=> p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(p => p.InStock)
                .IsRequired();


            //seed data
            builder.HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 1",
                    Description = "Description for Product 1",
                    DiscountPercentage = 10,
                    Price = 100,
                    MainImageUrl = "https://via.placeholder.com/150",
                    InStock = true,
                    IsNew = true
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 2",
                    Description = "Description for Product 2",
                    DiscountPercentage = 20,
                    Price = 200,
                    MainImageUrl = "https://via.placeholder.com/150",
                    InStock = false,
                    IsNew = false
                }
            );
        }
    }
}
