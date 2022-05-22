using PlantShop.Data.Context;
using PlantShop.Data.Models;

namespace PlantShop.Service.Repository
{
    public class OrderRepository : EfCoreRepository<Order, PlantShopContext>
    {
        public OrderRepository(PlantShopContext context) : base(context)
        {
        }
    }
}