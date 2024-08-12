using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgWalks.Api.Data;
using NgWalks.Api.Models.Domain;
using NgWalks.Api.Models.DTO;

namespace NgWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly NgWalksDbContext dbContext;

        public RegionController(NgWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regionDomain = dbContext.Regions.ToList();

            //Map Domain Models to Dtos
            var regionDto = new List<RegionDto>();
            foreach (var region in regionDomain)
            {
                regionDto.Add(new RegionDto
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }

            return Ok(regionDto);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var regions = dbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (regions == null)
            {
                return NotFound();
            }

            //map domain models to Dtos
            var regionDto = new RegionDto
            {
                Id = regions.Id,
                Name = regions.Name,
                Code = regions.Code,
                RegionImageUrl = regions.RegionImageUrl,
            };
            return Ok(regionDto);
            
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDtos addRegionRequestDtos)
        {
            //Map addRegionRequestDtos to Domain
            var regionaDomain = new Region
            {
                Code = addRegionRequestDtos.Code,
                Name = addRegionRequestDtos.Name,
                RegionImageUrl = addRegionRequestDtos.RegionImageUrl
            };

            dbContext.Regions.Add(regionaDomain);
            dbContext.SaveChanges();

            //Map Domain to Dtos
            var createDto = new RegionDto
            {
                Id = regionaDomain.Id,
                Name = regionaDomain.Name,
                Code = regionaDomain.Code,
                RegionImageUrl = regionaDomain.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = createDto.Id }, createDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update(Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            var updateDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (updateDomain == null)
            {
                return NotFound();
            }

            //Map Dto to domain
            updateDomain.Code = updateRegionRequest.Code;
            updateDomain.Name = updateRegionRequest.Name;
            updateDomain.RegionImageUrl = updateRegionRequest.RegionImageUrl;

            dbContext.SaveChanges();

            //map domain to dto
            var updateRegionDto = new RegionDto
            {
                Id = updateDomain.Id,
                Code = updateDomain.Code,
                Name = updateDomain.Name,
                RegionImageUrl = updateDomain.RegionImageUrl
            };
            

            return Ok(updateRegionDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var updateDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (updateDomain == null)
            {
                return NotFound(updateDomain);
            }

            dbContext.Remove(updateDomain);

            dbContext.SaveChanges();

            return Ok();
        }
    }
}
