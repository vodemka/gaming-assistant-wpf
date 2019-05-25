using GamingAssistant.Models.ComponentsModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamingAssistant.UserContorls
{
    public partial class ActiveChallenges : UserControl
    {
        public ActiveChallenges()
        {
            InitializeComponent();
            ShowActiveChallenges();
        }

        public void ShowActiveChallenges()
        {
            listOfActiveChallenges.ItemsSource = null;
            using (AppDbContext db = new AppDbContext())
            {
                db.UserChallenges.Load();
                var activeChallenges = db.UserChallenges.Local.Where(p => p.IsCompleted == false);
                List<Challenge> challenges = new List<Challenge>();
                List<User> users = new List<User>();

                foreach (var us in db.UserChallenges.Local)
                {
                    users.Add(us.User);
                }
                foreach (var ch in db.UserChallenges.Local)
                {
                    challenges.Add(ch.Challenge);
                }
                listOfActiveChallenges.ItemsSource = activeChallenges;
            }
        }

        private void RefreshUserChallenges_Click(object sender, RoutedEventArgs e)
        {
            ShowActiveChallenges();
        }

        private void ConfirmChallengeButton_Click(object sender, RoutedEventArgs e)
        {
            var uch = (UserChallenge)((Button)sender).Tag;
            ConfirmChallengeWindow confirmChallengeWindow = new ConfirmChallengeWindow(this, uch);
            confirmChallengeWindow.ShowDialog();
        }
    }
}
