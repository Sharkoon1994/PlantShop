using System.ComponentModel.DataAnnotations;

namespace PlantShop.Api.Models
{
    public class PlantModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}