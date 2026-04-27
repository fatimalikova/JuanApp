using JuanApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JuanApp.Data.Configurations
{
    public class RecentPostConfiguration : IEntityTypeConfiguration<RecentPost>
    {
        public void Configure(EntityTypeBuilder<RecentPost> builder)
        {
            builder.Property(rp => rp.BlogId)
                   .IsRequired();

        }
    }
}
