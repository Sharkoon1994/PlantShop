using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantShop.Contracts;
using PlantShop.Data.Entities;
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

        [HttpGet("get")]
        public async Task<List<Plant>> Get()
        {
            return await _plantService.GetAll();
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Plant>> Get(int id)
        {
            var plant = await _plantService.Get(id);

            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] PlantRequest? request)
        {
            if (request == null)
            {
                return BadRequest("Request is empty.");
            }

            var plant = await _plantService.Add(request.Name, request.Description, request.Price);

            return Created("", plant);
        }
    }
}