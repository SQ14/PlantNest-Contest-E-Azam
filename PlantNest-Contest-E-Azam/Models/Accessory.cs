using System.ComponentModel.DataAnnotations;

namespace PlantNest_Contest_E_Azam.Models
{
    public class Accessory
    {
        [Key]
        public int accessory_id { get; set; }
        public string accessory_name { get; set; }
        public string accessory_purpose { get; set; }
        public decimal accessory_price { get; set; }
        public int? accessory_quantity { get; set; }
        public string accessory_image { get; set; }
    }
}
