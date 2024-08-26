using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantNest_Contest_E_Azam.Models
{
    public class Review
    {
        [Key]
        public int review_id { get; set; }
        public int user_id { get; set; }
        public int? plant_id { get; set; }
        public int? accessory_id { get; set; }
        public int Rating { get; set; }
        public string review_comment { get; set; }
        public DateTime review_date { get; set; }

        [ForeignKey("user_id")]
        public User users { get; set; }
        
        [ForeignKey("plant_id")]
        public Plant plants { get; set; }
        
        [ForeignKey("accessory_id")]
        public Accessory accessories { get; set; }
    }
}
