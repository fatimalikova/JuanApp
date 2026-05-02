using JuanApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanApp.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(pi => pi.ImageUrl)
                .IsRequired(false);

            //seed data
            builder.HasData(
                new ProductImage
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    ImageUrl = "https://example.com/images/product1.jpg",
                    ProductId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
                },
                new ProductImage
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    ImageUrl = "https://example.com/images/product2.jpg",
                    ProductId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
                }
            );

        }
    }
}
