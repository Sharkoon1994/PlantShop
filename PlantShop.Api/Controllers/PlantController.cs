using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantShop.Data.Entities;
using PlantShop.Service.Repository;

namespace PlantShop.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/plant")]
    public class PlantController : ControllerBase
    {
        private readonly IPlantRepository _plantRepository;

        public PlantController(IPlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        [HttpPost]
        [Route("/add")]
        public async Task<IActionResult> Post([FromBody] Plant plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var model = await _plantRepository.InsertPlant(plant);

            return Ok(model);
        }

        [HttpGet]
        [Route("/all")]
        public async Task<IActionResult> Get()
        {
            var plants = await _plantRepository.GetPlants();

            return Ok(plants);
        }

        [HttpGet]
        [Route("/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var plant = await _plantRepository.GetPlantById(id);

            return Ok(plant);
        }

        [HttpDelete]
        [Route("/{id}")]
        public void Delete(int id)
        {
            _plantRepository.DeletePlant(id);
        }
    }
}