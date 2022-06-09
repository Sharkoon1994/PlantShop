using Microsoft.EntityFrameworkCore;
using PlantShop.Data;
using PlantShop.Data.Entities;

namespace PlantShop.Service
{
    public class PlantService : IPlantService
    {
        private readonly PlantShopContext _context;

        public PlantService(PlantShopContext context)
        {
            _context = context;
        }

        public async Task<Plant?> Get(int id)
        {
            var plant = await _context.Plants!.FindAsync(id).ConfigureAwait(false);
            
            return plant;
        }

        public async Task<List<Plant>> GetAll()
        {
             var plant = await _context.Set<Plant>().ToListAsync().ConfigureAwait(false);

             return plant;
        }

        public async Task<Plant> Add(string? name, string? description, double price)
        {
            var plant = new Plant
            {
                Name = name,
                Description = description,
                Price = price
            };

            await _context.Set<Plant>().AddAsync(plant);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return plant;
        }

        public async Task Delete(int id)
        {
            var plant = await Get(id);

            if (plant != null) _context.Set<Plant>().Remove(plant);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}