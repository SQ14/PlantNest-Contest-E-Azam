using System.ComponentModel.DataAnnotations;

namespace PlantNest_Contest_E_Azam.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string? user_contact { get; set; }
        public string? user_username { get; set; }
        public string user_password { get; set; }
        public string user_image { get; set; }
    }
}
