using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingAssistant.Models.ComponentsModel
{
    public class Log
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime? Time { get; set; } = null;

        public override string ToString()
        {
            return Action + " - " + Time;
        }
    }
}
