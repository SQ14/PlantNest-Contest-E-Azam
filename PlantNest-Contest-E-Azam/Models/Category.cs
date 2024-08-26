using System.ComponentModel.DataAnnotations;

namespace PlantNest_Contest_E_Azam.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }

        public List<Plant> plants { get; set; }
    }
}
