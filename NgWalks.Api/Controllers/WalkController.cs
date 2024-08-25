using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgWalks.Api.CustomValidation;
using NgWalks.Api.Models.Domain;
using NgWalks.Api.Models.DTO;
using NgWalks.Api.Repositories;

namespace NgWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidationModel]
        public async Task<IActionResult> CreateAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map Dto to Domain
            var walk = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateAsync(walk);

            //Map Domain to Dto
            var createDto = mapper.Map<WalkDto>(walk);

            return Ok(createDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetallAsync(string? filterOn, string? filterQuery,
            string? sortBy, bool? isAscending,int pageNumber = 1, int pagesize = 100)
        {
            var walks = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true,
                pageNumber, pagesize);
            var walk = mapper.Map<List<WalkDto>>(walks);
            return Ok(walk);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walksModel = await walkRepository.GetByIdAsync(id);
            if(walksModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walksModel));
        }

        [HttpPut("{id:guid}")]
        [ValidationModel]
        public async Task<IActionResult> UpdateWalksAsync([FromRoute]Guid id, UpdateWalkDto updateWalkDto)
        {
            var updateModel = mapper.Map<Walk>(updateWalkDto);
            updateModel = await walkRepository.UpdateWalkAsync(id, updateModel);
            if(updateModel == null)
            {
                return NotFound();
            }
            var update = mapper.Map<WalkDto>(updateModel);
            return Ok(update);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletWalksAsync([FromRoute] Guid id)
        {
            
            var updateModel = await walkRepository.DeleteWalkAsync(id);

            if (updateModel == null)
            {
                return NotFound();
            }
            var update = mapper.Map<WalkDto>(updateModel);
            return Ok(update);
        }


    }
}
