using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNest_Contest_E_Azam.Models
{
    public class Cart
    {
        [Key]

        public int cart_id { get; set; }
        public int user_id { get; set; }
        public int? plant_id { get; set; }
        public int? accessory_id { get; set; }
        public int? plant_quantity { get; set; }
        public int? accessory_quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string cart_status { get; set; }

        [ForeignKey("plant_id")]
        public Plant plants { get; set; }

        [ForeignKey("user_id")]
        public User users { get; set; }
    }
}
