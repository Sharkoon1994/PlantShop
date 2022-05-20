using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantShop.Api.Models;
using PlantShop.Api.Repository;

namespace PlantShop.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/plant")]
    public class PlantController : ControllerBase
    {
        private readonly IPlantRepository _plantService;

        public PlantController(IPlantRepository plantService)
        {
            _plantService = plantService;
        }

        [HttpPost]
        [Route("/add")]
        public async Task<IActionResult> Post([FromBody] Plant plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var model = await _plantService.AddPlant(plant);

            return Ok(model);
        }

        [HttpGet]
        [Route("/all")]
        public async Task<IActionResult> Get()
        {
            var plants = await _plantService.GetPlants();

            return Ok(plants);
        }

        [HttpGet]
        [Route("/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var plant = await _plantService.GetPlant(id);

            return Ok(plant);
        }
    }
}