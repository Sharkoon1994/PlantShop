using Microsoft.EntityFrameworkCore;
using PlantShop.Data.Models;

namespace PlantShop.Data.Context
{
    public class PlantShopContext : DbContext
    {
        public PlantShopContext(DbContextOptions<PlantShopContext> options) : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
        //public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().ToTable(nameof(Plant));
        }
    }
}