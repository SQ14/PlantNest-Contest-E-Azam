using System.ComponentModel.DataAnnotations;

namespace PlantNest_Contest_E_Azam.Models
{
    public class Plant
    {
        [Key]
        public int plant_id { get; set; }
        public string plant_name { get; set; }
        public string plant_species { get; set; }
        public decimal plant_price { get; set; }
        public int? plant_quantity { get; set; }
        public decimal? plant_discount { get; set; }
        public string plant_description { get; set; }
        public string plant_image { get; set; }
        public int category_id { get; set; }

        public Category categories { get; set; }
    }
}
