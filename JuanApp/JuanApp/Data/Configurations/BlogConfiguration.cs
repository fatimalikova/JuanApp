using JuanApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanApp.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.Id);
            //Related Blogs connection
            builder.HasMany(b => b.RelatedBlogs)
                   .WithOne(rb => rb.Blog)
                   .HasForeignKey(rb => rb.BlogId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
