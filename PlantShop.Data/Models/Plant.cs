using PlantShop.Data.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantShop.Data.Models
{
    public class Plant : IEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Description { get; set; }

        public double Price { get; set; }
    }
}