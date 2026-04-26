using JuanApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanApp.Data.Configurations
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.ColorId });
                builder.HasOne(ps => ps.Product)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(ps => ps.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ps => ps.Color)
                .WithMany(c => c.ProductColors)
                .HasForeignKey(ps => ps.ColorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
