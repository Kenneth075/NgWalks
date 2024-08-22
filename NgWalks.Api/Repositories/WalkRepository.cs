using Microsoft.EntityFrameworkCore;
using NgWalks.Api.Data;
using NgWalks.Api.Models.Domain;

namespace NgWalks.Api.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NgWalksDbContext dbContext;

        public WalkRepository(NgWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            var walks = await dbContext.Walks.Include(x=>x.DifficultyId).Include(x => x.Region).AsNoTracking().ToListAsync();
            return walks;
        }
    }
}
