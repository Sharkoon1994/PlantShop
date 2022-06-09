using Microsoft.EntityFrameworkCore;
using PlantShop.Data.Entities;
using PlantShop.Data.EntityConfiguration;

namespace PlantShop.Data
{
    public class PlantShopContext : DbContext
    {
        public PlantShopContext(DbContextOptions<PlantShopContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new PlantShopEntityConfiguration());
        }

        public DbSet<Plant>? Plants { get; set; }
    }
}