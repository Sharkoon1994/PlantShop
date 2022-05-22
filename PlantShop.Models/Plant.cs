using System.ComponentModel.DataAnnotations;
using PlantShop.Data;

namespace PlantShop.Models
{
    public class Plant : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string? Description { get; set; }

        public double Price { get; set; }
    }
}