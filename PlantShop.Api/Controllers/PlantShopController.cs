using Microsoft.AspNetCore.Mvc;
using PlantShop.Data.Generic;
using PlantShop.Service.Generic;

namespace PlantShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class PlantShopController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        protected PlantShopController(TRepository repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id:int}", Name = "Get")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var movie = await _repository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, TEntity movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            await _repository.Update(movie);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity movie)
        {
            await _repository.Add(movie);
            return CreatedAtAction("Get", new {id = movie.Id}, movie);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var movie = await _repository.Delete(id);
            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }
    }
}