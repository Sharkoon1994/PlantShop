using Microsoft.EntityFrameworkCore;
using PlantShop.Data.Context;
using PlantShop.Data.Entities;

namespace PlantShop.Service.Repository
{
    public class PlantRepository : IPlantRepository, IDisposable
    {
        private readonly PlantContext _context;
        private bool _disposed;

        public PlantRepository(PlantContext context)
        {
            _context = context;
        }

        public async Task<List<Plant>> GetPlants()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task<Plant> GetPlantById(int id)
        {
            return await _context.Plants.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Plant> InsertPlant(Plant plant)
        {
            var entity = await _context.Plants.AddAsync(plant);
            await _context.SaveChangesAsync();

            return entity.Entity;
        }

        public async void DeletePlant(int id)
        {
            var plant = await GetPlantById(id);
            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}