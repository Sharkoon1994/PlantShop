using System.ComponentModel.DataAnnotations;
using PlantShop.Data.Generic;

namespace PlantShop.Data.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Item { get; set; }

        public int Amount { get; set; }

        public double TotalPrice { get; set; }
    }
}