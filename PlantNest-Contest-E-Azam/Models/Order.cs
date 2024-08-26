using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNest_Contest_E_Azam.Models
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public int cart_id { get; set; }
        public int order_quantity { get; set; }
        public decimal order_price { get; set; }
        public string order_status { get; set; }
        public DateTime order_date { get; set; }

        [ForeignKey("cart_id")]
        public Cart carts { get; set; }
    }
}
