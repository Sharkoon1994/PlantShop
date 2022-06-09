using System.ComponentModel.DataAnnotations;

namespace PlantShop.Contracts
{
    public class PlantRequest
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }
    }
}