using GamingAssistant.Models.ComponentsModel;
using System;
using BespokeFusion;
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
    public partial class Challenges : UserControl
    {
        public ObservableCollection<Challenge> challenges;
        public Challenges()
        {
            using (AppDbContext db = new AppDbContext())
            {
                InitializeComponent();
                challenges = new ObservableCollection<Challenge>();
                db.Users.Load();
                db.Games.Load();
                foreach (var challenge in db.Challenges)
                {
                    challenges.Add(challenge);
                }
                DataGridChallenges.ItemsSource = challenges;
            }
        }

        private void AddNewChallengeClick(object sender, RoutedEventArgs e)
        {
            CreateChallengeWindow createChallengeWindow = new CreateChallengeWindow(this);
            createChallengeWindow.ShowDialog();
        }

        private void TakeChallengeClick(object sender, RoutedEventArgs e)
        {
            if (DataGridChallenges.SelectedItem != null)
            {
                Challenge selectedChallenge = (Challenge)DataGridChallenges.SelectedItem;
                using (AppDbContext db = new AppDbContext())
                {
                    db.Challenges.Load();
                    Challenge challenge = db.Challenges.Find(selectedChallenge.Id);
                    User user = db.Users.Find(App.CurrentUser.Id);
                    int countOfActiveChallengesOnUser = user.UserChallenge.Where(p => p.IsCompleted == false).Count();
                    bool isCreatedByUser = false;
                    bool isUserHaveAnyActive = countOfActiveChallengesOnUser > 0;
                    bool isEverComplete = false;

                    if (db.Challenges.Find(selectedChallenge.Id).Creator==user)
                    {
                        isCreatedByUser = true;
                    }
                    foreach (var ch in user.UserChallenge)
                    {
                        if (challenge.Id == ch.ChallengeId)
                        {
                            isEverComplete = true;
                        }
                    }
                    if (isUserHaveAnyActive)
                    {
                        MaterialMessageBox.Show("У Вас уже есть активный вызов", "Ошибка");
                        DataGridChallenges.SelectedItem = null;
                    } else
                    if (isEverComplete)
                    {
                        MaterialMessageBox.Show("Вы уже выполняли данный вызов!", "Упс..");
                        DataGridChallenges.SelectedItem = null;
                    } else
                    if (isCreatedByUser)
                    {
                        MaterialMessageBox.Show("Вы не можете принять созданый Вами вызов", "Ошибка");
                        DataGridChallenges.SelectedItem = null;
                    }
                    else
                    {
                        UserChallenge userChallenge = new UserChallenge() { User = user, Challenge = challenge, AcceptTime=DateTime.Now };
                        db.UserChallenges.Add(userChallenge);
                        db.SaveChanges();
                        MaterialMessageBox.Show("Отлично! Вызов добавлен", "Успех");
                        DataGridChallenges.SelectedItem = null;
                    }
                }
            }
            else
            {
                MaterialMessageBox.Show("Сначала нужно выбрать вызов", "Ошибка");
            }
        }

        private void RefreshChallengesClick(object sender, RoutedEventArgs e)
        {
            using (AppDbContext db = new AppDbContext())
            {
                challenges = new ObservableCollection<Challenge>();
                db.Users.Load();
                db.Games.Load();
                foreach (var challenge in db.Challenges)
                {
                    challenges.Add(challenge);
                }
                DataGridChallenges.ItemsSource = challenges;
            }
        }
    }
}