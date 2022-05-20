using PlantShop.Api.Models;

namespace PlantShop.Api.Data
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

            var plant = new Plant?[]
            {
            new() {Name = "Orgidee"}
            };

            foreach (var p in plant)
            {
                await context.Plants.AddAsync(p!);
            }

            await context.SaveChangesAsync();
        }
    }
}