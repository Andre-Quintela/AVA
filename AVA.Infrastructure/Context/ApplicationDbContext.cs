using AVA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AVA.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
         public DbSet<User> Users { get; set; }  
    }
}