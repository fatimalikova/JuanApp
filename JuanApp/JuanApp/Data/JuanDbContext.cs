using JuanApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JuanApp.Data
{
    public class JuanDbContext(DbContextOptions<JuanDbContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JuanDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogRelation> BlogRelations { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
    }
}
