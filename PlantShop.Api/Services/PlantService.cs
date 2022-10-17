using Microsoft.EntityFrameworkCore;
using PlantShop.Api.Context;
using PlantShop.Api.Models;

namespace PlantShop.Api.Service
{
    public class PlantService : IPlantService
    {
        private readonly PlantShopContext _context;

        public PlantService(PlantShopContext context)
        {
            _context = context;
        }

        public async Task<PlantModel?> Get(int id)
        {
            return await _context.Plants!.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<List<PlantModel>> GetAll()
        {
            return await _context.Set<PlantModel>().ToListAsync().ConfigureAwait(false);
        }

        public async Task<PlantModel> Add(string? name, string? description, double price)
        {
            var plant = new PlantModel
            {
                Name = name,
                Description = description,
                Price = price
            };

            await _context.Set<PlantModel>().AddAsync(plant);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return plant;
        }

        public async Task Delete(int id)
        {
            var plant = await Get(id);

            if (plant != null) _context.Set<PlantModel>().Remove(plant);

            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}