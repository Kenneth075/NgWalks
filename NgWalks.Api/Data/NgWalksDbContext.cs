using Microsoft.EntityFrameworkCore;
using NgWalks.Api.Models.Domain;

namespace NgWalks.Api.Data
{
    public class NgWalksDbContext : DbContext
    {
        public NgWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
    }
}
