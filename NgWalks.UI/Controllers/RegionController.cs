using Microsoft.AspNetCore.Mvc;
using NgWalks.UI.Models.Dto;

namespace NgWalks.UI.Controllers
{
    public class RegionController : Controller
    {
        private readonly IHttpClientFactory httpClient;
        private readonly IConfiguration configuration;

        public RegionController(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<RegionDto> res = new List<RegionDto>();
            try
            {
                //Get region Api
                var regionApiUrl = configuration.GetValue<string>("Region:RegionApi");
                var client = httpClient.CreateClient();
                var response = await client.GetAsync(regionApiUrl);

                response.EnsureSuccessStatusCode();
                res.AddRange(await response.Content.ReadFromJsonAsync<IEnumerable<RegionDto>>());

               
            }
            catch (Exception)
            {

                throw;
            }
            return View(res);
        }
    }
}
