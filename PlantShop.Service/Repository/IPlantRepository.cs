using PlantShop.Data.Entities;

namespace PlantShop.Service.Repository
{
    public interface IPlantRepository
    {
        Task<List<Plant>> GetPlants();
        Task<Plant> GetPlantById(int id);
        Task<Plant> InsertPlant(Plant plant);
        void DeletePlant(int id);
    }
}