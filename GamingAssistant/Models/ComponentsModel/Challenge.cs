using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingAssistant.Models.ComponentsModel
{
    public class Challenge
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        public virtual User Creator { get; set; }
        public int? CreatorId { get; set; }

        public virtual Game Game { get; set; }
        public int? GameId { get; set; }

        public int CountOfComplete { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Challenge()
        {
            Users = new List<User>();
        }

        //public Challenge(string title, string text, User user, Game game)
        //{
        //    Title = title;
        //    Text = text;
        //    Creator = user;
        //    Game = game;
        //}

        //public override string ToString()
        //{
        //    return Text;
        //}
    }

   
}
