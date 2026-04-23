using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JuanApp.Data
{
    public class JuanDbContext(DbContextOptions<JuanDbContext> options) : DbContext(options)
    {
        
        // Define your DbSets here, for example:
        // public DbSet<Product> Products { get; set; }
    }
}
