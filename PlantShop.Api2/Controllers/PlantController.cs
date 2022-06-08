using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantShop.Contracts;
using PlantShop.Service;

namespace PlantShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PlantController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post([FromBody] PlantRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request object is empty.");
            }

            await _plantService.Add(request.Name!, request.Description!, request.Price);

            return Ok();
        }
    }
}