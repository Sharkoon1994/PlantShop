using PlantShop.Api.Models;

namespace PlantShop.Api.Service
{
    public interface IPlantService
    {
        Task<PlantModel?> Get(int id);
        Task<List<PlantModel>> GetAll();
        Task<PlantModel> Add(string? name, string? description, double price);
        Task Delete(int id);
    }
}