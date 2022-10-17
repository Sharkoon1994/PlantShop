using Microsoft.EntityFrameworkCore;
using PlantShop.Api.Models;

namespace PlantShop.Api.Context
{
    public class PlantShopContext : DbContext
    {
        public PlantShopContext(DbContextOptions<PlantShopContext> options) : base(options)
        { }
        
        public DbSet<PlantModel> Plants { get; set; }
    }
}