using Microsoft.EntityFrameworkCore;
using PlantShop.Api.Models;

namespace PlantShop.Api.Data
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