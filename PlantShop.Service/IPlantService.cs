using PlantShop.Data.Entities;

namespace PlantShop.Service
{
    public interface IPlantService
    {
        Task<Plant?> Get(int id);
        Task<List<Plant>> GetAll();
        Task<Plant> Add(string? name, string? description, double price);
        Task Delete(int id);
    }
}