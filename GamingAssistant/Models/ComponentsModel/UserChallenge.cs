using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingAssistant.Models.ComponentsModel
{
    public class UserChallenge
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? ChallengeId { get; set; }
        public virtual Challenge Challenge { get; set; }

        public bool IsCompleted { get; set; } = false;
        public string ProofLink { get; set; }
        public DateTime? AcceptTime { get; set; } = null;
        public DateTime? ConfirmTime { get; set; } = null;
        public bool IsUserReady { get; set; } = false;

        public UserChallenge()
        {

        }
    }
}
