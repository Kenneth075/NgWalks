using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public WalkController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody]AddWalkRequestDto addWalkRequestDto)
        {
            //Map Dto to Domain
            var walk = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateAsync(walk);

            //Map Domain to Dto
            var createDto = mapper.Map<WalkDto>(walk);

            return Ok(createDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetallAsync()
        {
            var walks = await walkRepository.GetAllAsync();
            mapper.Map<List<WalkDto>>(walks);
            return Ok(walks);
        }
    }
}
