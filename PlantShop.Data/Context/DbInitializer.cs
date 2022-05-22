using PlantShop.Data.Models;

namespace PlantShop.Data.Context
{
    public static class DbInitializer
    {
        public static async Task Initialize(PlantShopContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!context.Plants.Any())
            {

                var plant = new Plant[]
                {
                    new()
                    {
                        Name = "Orchidee",
                        Description = "Starting plant",
                        Price = 2.59
                    }
                };

                await context.Plants.AddRangeAsync(plant);
            }

            //if (!context.Orders.Any())
            //{

            //    var order = new Order[]
            //    {
            //        new()
            //        {
            //            Item = "Orchidee",
            //            Amount = 1,
            //            TotalPrice = 2.59
            //        }
            //    };

            //    await context.Orders.AddRangeAsync(order);
            //}


            await context.SaveChangesAsync();
        }
    }
}