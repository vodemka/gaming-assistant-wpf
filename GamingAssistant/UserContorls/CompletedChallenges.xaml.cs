using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Логика взаимодействия для CompletedChallenges.xaml
    /// </summary>
    public partial class CompletedChallenges : UserControl
    {
        public CompletedChallenges()
        {
            InitializeComponent();
            ShowAllCompleted();
        }

        private void ShowAllCompleted_Click(object sender, RoutedEventArgs e)
        {
            ShowAllCompleted();
        }

        private void ShowCompletedByUser_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Challenges.Load();
                db.Users.Load();
                ListOfCompletedChallenges.ItemsSource = db.UserChallenges.Where(p => p.User.Id == App.CurrentUser.Id && p.IsCompleted == true).ToList();
            }
        }

        private void ShowAllCompleted()
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Challenges.Load();
                db.Users.Load();
                ListOfCompletedChallenges.ItemsSource = db.UserChallenges.Where(p => p.IsCompleted == true).ToList();
            }
        }
    }
}
