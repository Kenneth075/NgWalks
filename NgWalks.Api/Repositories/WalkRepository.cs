using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NgWalks.Api.Data;
using NgWalks.Api.Models.Domain;
using NgWalks.Api.Models.DTO;

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

        public async Task<Walk?> DeleteWalkAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pagesize = 100)
        {
            var walks =  dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

            //filtering
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if(sortBy.Equals("LengthInKm", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
                
            }

            //pagination
            var skipResult = (pageNumber - 1) * pagesize;

            //var walks = await dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsNoTracking().ToListAsync();
            //return walks;

            return await walks.Skip(skipResult).Take(pagesize).ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateWalkAsync(Guid id, Walk walk)
        {
            var existingwalks = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingwalks == null)
            {
                return null;
            }

            existingwalks.Name = walk.Name;
            existingwalks.Description = walk.Description;
            existingwalks.LengthInKm = walk.LengthInKm;
            existingwalks.WalkImageUrl = walk.WalkImageUrl;
            existingwalks.RegionId = walk.RegionId;
            existingwalks.DifficultyId = walk.DifficultyId;

            
            await dbContext.SaveChangesAsync();
            return existingwalks;
        }
    }
}
