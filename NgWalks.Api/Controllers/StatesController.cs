using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NgWalks.Api.Models.DTO;
using NgWalks.Api.Repositories;

namespace NgWalks.Api.Controllers
{
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Authorize]
    public class StatesController : ControllerBase
    {
        public StatesController()
        {
            
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetStatesAsync()
        {
            var statesDomainModel = StatesRepo.GetStates();

            var response = new List<NgStatesDtoV1>();

            foreach(var state in statesDomainModel)
            {
                response.Add(new NgStatesDtoV1
                {
                    Name = state.Name,
                    Code = state.Code
                });
            }

            return Ok(response);
        }


        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetStatesAsync2()
        {
            var statesDomainModel = StatesRepo.GetStates();

            var response = new List<NgStatesDtoV2>();

            foreach (var state in statesDomainModel)
            {
                response.Add(new NgStatesDtoV2
                {
                    Name = state.Name,
                    StateCode = state.Code
                });
            }

            return Ok(response);
        }
    }
}
