using NgWalks.Api.Models.Domain;
using NgWalks.Api.Models.DTO;

namespace NgWalks.Api.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
    }
}
