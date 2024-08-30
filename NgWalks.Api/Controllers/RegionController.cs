using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NgWalks.Api.CustomValidation;
using NgWalks.Api.Data;
using NgWalks.Api.Models.Domain;
using NgWalks.Api.Models.DTO;
using NgWalks.Api.Repositories;

namespace NgWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase 
    {
        private readonly NgWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(NgWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllAsync()
        {
            var regionDomain = await regionRepository.GetAllAsync();

            //Map Domain Models to Dtos
            //var regionDto = new List<RegionDto>();
            //foreach (var region in regionDomain)
            //{
            //    regionDto.Add(new RegionDto
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });
            //}
            var regionDto = mapper.Map<List<RegionDto>>(regionDomain);

            return Ok(regionDto);

        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var regions = await regionRepository.GetByIdAsync(id);

            if (regions == null)
            {
                return NotFound();
            }

            //map domain models to Dtos
            //var regionDto = new RegionDto
            //{
            //    Id = regions.Id,
            //    Name = regions.Name,
            //    Code = regions.Code,
            //    RegionImageUrl = regions.RegionImageUrl,
            //};

            var regionDto = mapper.Map<RegionDto>(regions);
            return Ok(regionDto);
            
        }

        [HttpPost]
        [ValidationModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDtos addRegionRequestDtos)
        {
            //Map addRegionRequestDtos to Domain

            //var regionaDomain = new Region
            //{
            //    Code = addRegionRequestDtos.Code,
            //    Name = addRegionRequestDtos.Name,
            //    RegionImageUrl = addRegionRequestDtos.RegionImageUrl
            //};
            var regionaDomain = mapper.Map<Region>(addRegionRequestDtos);

            await regionRepository.CreateAsync(regionaDomain);

            //Map Domain to Dtos

            //var createDto = new RegionDto
            //{
            //    Id = regionaDomain.Id,
            //    Name = regionaDomain.Name,
            //    Code = regionaDomain.Code,
            //    RegionImageUrl = regionaDomain.RegionImageUrl,
            //};

            var createDto = mapper.Map<RegionDto>(regionaDomain);

            return CreatedAtAction(nameof(GetById), new { id = createDto.Id }, createDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidationModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            //Map Dto to domain

            //var updateRegionDomain = new Region
            //{
            //    Code = updateRegionRequest.Code,
            //    Name = updateRegionRequest.Name,
            //    RegionImageUrl = updateRegionRequest.RegionImageUrl
            //};

            var updateRegionDomain = mapper.Map<Region>(updateRegionRequest);

            updateRegionDomain = await regionRepository.UpdateAsync(id, updateRegionDomain);
            if (updateRegionDomain == null)
            {
                return NotFound();
            }

            dbContext.SaveChanges();

            //map domain to dto
            //var updateRegionDto = new RegionDto
            //{
            //    Id = updateRegionDomain.Id,
            //    Code = updateRegionDomain.Code,
            //    Name = updateRegionDomain.Name,
            //    RegionImageUrl = updateRegionDomain.RegionImageUrl
            //};

            var updateRegionDto = mapper.Map<RegionDto>(updateRegionDomain);

            return Ok(updateRegionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var updateDomain = await regionRepository.DeleteAsync(id);
            if (updateDomain == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
