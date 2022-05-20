using System.ComponentModel.DataAnnotations;

namespace PlantShop.Api.Models
{
    public class Plant
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}