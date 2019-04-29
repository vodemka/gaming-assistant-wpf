using System.ComponentModel.DataAnnotations;

namespace GamingAssistant
{
    public class User
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
