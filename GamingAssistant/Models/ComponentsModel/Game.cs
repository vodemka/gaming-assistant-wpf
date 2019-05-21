using System.Collections.Generic;

namespace GamingAssistant.Models.ComponentsModel
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Game()
        {
            Comments = new List<Comment>();
            Users = new List<User>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
