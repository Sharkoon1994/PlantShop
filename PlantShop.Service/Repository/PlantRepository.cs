using PlantShop.Data.Context;
using PlantShop.Data.Models;

namespace PlantShop.Service.Repository
{
    public class PlantRepository : EfCoreRepository<Plant, PlantShopContext>
    {
        public PlantRepository(PlantShopContext context) : base(context)
        {
        }
    }
}