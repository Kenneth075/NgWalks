﻿using NgWalks.Api.Models.Domain;
using NgWalks.Api.Models.DTO;

namespace NgWalks.Api.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pagesize = 100);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk?> UpdateWalkAsync(Guid id, Walk walk);
        Task<Walk?> DeleteWalkAsync(Guid id);
    }
}
