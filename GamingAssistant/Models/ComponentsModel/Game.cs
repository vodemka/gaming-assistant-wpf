using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingAssistant.Models.ComponentsModel
{
    public class Game
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public string Image { get; set; }

        public Game(string name, double rating, string image)
        {
            Name = name;
            Rating = rating;
            Image = image;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
