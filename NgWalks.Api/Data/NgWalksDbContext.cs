using Microsoft.EntityFrameworkCore;
using NgWalks.Api.Models.Domain;

namespace NgWalks.Api.Data
{
    public class NgWalksDbContext : DbContext
    {
        public NgWalksDbContext(DbContextOptions<NgWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Difficulty>().HasData()
            var diff = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("53588cb0-2b1b-42a0-a45a-488e3791fc00"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("ba089749-2153-4b78-abda-9ee2611c8db7"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("296bf176-a66f-4f86-b806-0535af9a5de4"),
                    Name = "Hard"
                },

                
            };
            modelBuilder.Entity<Difficulty>().HasData(diff);

            modelBuilder.Entity<Region>().HasData(
                new Region
                {
                    Id = Guid.Parse("8ad9b8c9-a00f-480d-a9a1-a57fee37e79a"),
                    Code = "AKS",
                    Name = "Akwa Ibom",
                    RegionImageUrl = "AkwaIbom.Aks.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("5bc41d79-4617-40d9-801d-e321f7b44675"),
                    Code = "RIV",
                    Name = "Rivers",
                    RegionImageUrl = "Rivers.RIV.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("85a0cd50-abad-4896-9e0c-8beace050a18"),
                    Code = "BAY",
                    Name = "Bayelsa",
                    RegionImageUrl = "Bayelsa.BAY.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("24b413a1-85b9-4abd-8d52-d41c0aec202a"),
                    Code = "LAG",
                    Name = "Lagos",
                    RegionImageUrl = ""
                },
                new Region
                {
                    Id = Guid.Parse("382c02d4-70ed-4392-8c23-3f6d3086aeab"),
                    Code = "ABI",
                    Name = "Abia",
                    RegionImageUrl = ""
                }
                );

        }
    }
}
