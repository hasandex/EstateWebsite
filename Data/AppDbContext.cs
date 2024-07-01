
using EstateWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EstateWebsite.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeImages> HomeImages { get; set; }
    }
}
