
using EstateWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace EstateWebsite.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstateImages> EstateImages { get; set; }
    }
}
