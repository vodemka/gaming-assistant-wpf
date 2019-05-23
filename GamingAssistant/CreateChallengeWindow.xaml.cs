using GamingAssistant.Models.ComponentsModel;
using GamingAssistant.UserContorls;
using System;
using BespokeFusion;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data.Entity;

namespace GamingAssistant
{
    /// <summary>
    /// Логика взаимодействия для CreateChallengeWindow.xaml
    /// </summary>
    public partial class CreateChallengeWindow : Window
    {
        Challenges challengesWindow;
        public CreateChallengeWindow()
        {
            InitializeComponent();
        }
        public CreateChallengeWindow(Challenges ch)
        {
            challengesWindow = ch;
            InitializeComponent();
            List<string> listOfGames = new List<string>();
            using (AppDbContext db = new AppDbContext())
            {
                db.Games.Load();
                db.Users.Load();
                User user = db.Users.Find(App.CurrentUser.Id);
                foreach (var game in user.Games)
                {
                    listOfGames.Add(game.Name);
                }
            }
            ComboBoxGames.ItemsSource = listOfGames;
            ComboBoxGames.SelectedIndex = 0;
        }

        private void WindowClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddNewChallengeClick(object sender, RoutedEventArgs e)
        {
            if (titleOfCreatedChallenge.Text == String.Empty)
            {
                MaterialMessageBox.Show("Укажите заголовок вызова", "Ошибка");
            }
            else if (textOfCreatedChallenge.Text == String.Empty)
            {
                MaterialMessageBox.Show("Напишите задание вызова", "Ошибка");
            }
            else if (ComboBoxGames.SelectedItem == null)
            {
                MaterialMessageBox.Show("Сначала нужно добавить игру", "Упс..");
            }
            else
            {
                NewChallenge(App.CurrentUser);
                Close();
            }
        }
        private void NewChallenge(User user)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Games.Load();
                db.Users.Load();
                Game selectedgame = db.Games.Local.Single(p => p.Name.Equals(ComboBoxGames.SelectedItem.ToString()));
                User selectedUser = db.Users.Local.Single(p => p.Id.Equals(user.Id));
                Challenge createdChallenge = new Challenge { Title = titleOfCreatedChallenge.Text, Text = textOfCreatedChallenge.Text, Creator = selectedUser, Game = selectedgame };
                challengesWindow.challenges.Add(createdChallenge);
                db.Challenges.Add(createdChallenge);

                User thiUser = db.Users.Find(App.CurrentUser.Id);
                Log log = new Log() { Time = DateTime.Now, Action = "Пользователь " + thiUser.Username + " добавил новый вызов: " + createdChallenge.Text };
                db.Logs.Add(log);
                db.SaveChanges();
            }
        }

        private void RangeDragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
