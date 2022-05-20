using Microsoft.EntityFrameworkCore;
using PlantShop.Api.Data;
using PlantShop.Api.Models;

// ReSharper disable InvertIf

namespace PlantShop.Api.Repository
{
    public class PlantRepository : IPlantRepository
    {
        private readonly PlantContext _context;

        public PlantRepository(PlantContext context)
        {
            _context = context;
        }

        public async Task<List<Plant>> GetPlants()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant> GetPlant(int id)
        {
            return (await _context.Plants.FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task<Plant> AddPlant(Plant plant)
        {
            var entity = await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();

            return entity.Entity;
        }

        public async void DeletePlant(int id)
        {
            var result = await _context.Plants.FirstOrDefaultAsync(
                x => x.Id == id);
            
            if (result != null)
            {
                _context.Plants.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}