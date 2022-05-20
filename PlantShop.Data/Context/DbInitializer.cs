using PlantShop.Data.Entities;

namespace PlantShop.Data.Context
{
    public static class DbInitializer
    {
        public static async Task Initialize(PlantContext context)
        {
            await context.Database.EnsureCreatedAsync();

            // Look for any students.
            if (context.Plants.Any())
            {
                return;   // DB has been seeded
            }

            var plant = new Plant[]
            {
            new() {Name = "Orchidee", Description = "Very nice"}
            };

            foreach (var p in plant)
            {
                await context.Plants.AddAsync(p!);
            }

            await context.SaveChangesAsync();
        }
    }
}