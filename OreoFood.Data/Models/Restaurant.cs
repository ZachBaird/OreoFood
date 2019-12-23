using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OreoFood.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Cuisine Type")]
        public CuisineType Cuisine { get; set; }
    }
}
