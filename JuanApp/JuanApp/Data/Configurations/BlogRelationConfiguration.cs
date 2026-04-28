using JuanApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanApp.Data.Configurations
{
    public class BlogRelationConfiguration : IEntityTypeConfiguration<BlogRelation>
    {
        public void Configure(EntityTypeBuilder<BlogRelation> builder)
        {
            builder.HasKey(br => br.Id);

            builder.Property(br => br.BlogId)
               .IsRequired();

            builder.Property(br => br.RelatedBlogId)
                   .IsRequired();

            // Configure the RelatedBlog relationship (second foreign key)
            // This is NOT configured in BlogConfiguration, so we handle it here
            builder.HasOne(br => br.RelatedBlog)
                   .WithMany()
                   .HasForeignKey(br => br.RelatedBlogId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasConstraintName("FK_BlogRelations_Blogs_RelatedBlogId");

            builder.ToTable("BlogRelations");
        }
    }
}
