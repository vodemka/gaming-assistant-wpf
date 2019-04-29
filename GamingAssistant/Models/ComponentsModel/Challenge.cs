using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingAssistant.Models.ComponentsModel
{
    public class Challenge
    {
        public string TextOfChallenge { get; set; }
        public string ChallengeTitle { get; set; }
        public User CreatorOfChallenge { get; set; }
        public Game GameForChallenge { get; set; }

        public Challenge(string title, string text, User user, Game game)
        {
            ChallengeTitle = title;
            TextOfChallenge = text;
            CreatorOfChallenge = user;
            GameForChallenge = game;
        }

        public override string ToString()
        {
            return TextOfChallenge;
        }
    }

   
}
