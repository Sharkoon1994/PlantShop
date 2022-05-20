using Microsoft.EntityFrameworkCore;
using PlantShop.Data.Entities;

namespace PlantShop.Data.Context
{
    public class PlantContext : DbContext
    {
        public PlantContext(DbContextOptions<PlantContext> options) : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>().ToTable("Plant");
        }
    }
}