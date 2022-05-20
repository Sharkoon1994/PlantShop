using PlantShop.Api.Models;

namespace PlantShop.Api.Repository
{
    public interface IPlantRepository
    {
        Task<List<Plant>> GetPlants();
        Task<Plant> GetPlant(int id);
        Task<Plant> AddPlant(Plant plant);
        void DeletePlant(int id);
    }
}