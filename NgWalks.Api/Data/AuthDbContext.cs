using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NgWalks.Api.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "3e1211c5-2155-4c86-8fc1-22086f3a1cf6";
            var writerRoleId = "0ac88a27-51bf-49c1-882d-51699bf2f92c";

            builder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = readerRoleId,
                   Name = "Reader",
                   ConcurrencyStamp = readerRoleId,
                   NormalizedName = "Reader".ToUpper()
               },
               new IdentityRole
               {
                   Id = writerRoleId,
                   Name = "Writer",
                   ConcurrencyStamp = writerRoleId,
                   NormalizedName = "Writer".ToUpper(),
               }
               );

            
        }
    }
}
