using GamingAssistant.Models.ComponentsModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamingAssistant
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        public string Hash { get; set; }

        public bool IsAdmin { get; set; }

        public virtual ICollection<Challenge> Challenges { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public User()
        {
            Challenges = new List<Challenge>();
            Games = new List<Game>();
        }
    }
}
