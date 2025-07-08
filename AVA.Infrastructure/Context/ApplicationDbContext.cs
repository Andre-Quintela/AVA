using Microsoft.EntityFrameworkCore;

namespace AVA.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add DbSet properties for your entities here, e.g.:  
        // public DbSet<User> Users { get; set; }  
    }
}