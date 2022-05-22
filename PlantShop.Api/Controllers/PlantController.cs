using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantShop.Data.Models;
using PlantShop.Service.Repository;

namespace PlantShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PlantController : PlantShopController<Plant, PlantRepository>
    {
        public PlantController(PlantRepository repository) : base(repository)
        {
        }
    }
}