using GamingAssistant.Models.ComponentsModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        public ObservableCollection<Game> games;
        public Home()
        {
                InitializeComponent();
                userInfoChip.Icon = App.CurrentUser.Username[0];
                userInfoChip.Content = App.CurrentUser.Username.ToUpper();
                ShowUserGames();
        }

        private void ChangeUserButton_Click(object sender, RoutedEventArgs e)
        {
            AuthentificationWindow authentificationWindow = new AuthentificationWindow();
            Window parentWindow = Window.GetWindow((DependencyObject)sender);
            if (parentWindow != null)
            {
                parentWindow.Close();
            }
            //------------LOADER---------------
            Thread myThread = new Thread(new ThreadStart(ShowLoader));
            myThread.SetApartmentState(ApartmentState.STA);
            myThread.Start();
            Thread.Sleep(1000);
            myThread.Abort();
            authentificationWindow.Show();
            //---------------------------------
        }
        private static void ShowLoader()
        {
            Loader loader = new Loader();
            loader.ShowDialog();
            loader.Close();
        }

        private void ShowUserGames()
        {
            using (AppDbContext db = new AppDbContext())
            {
                int countOfGames = 0;
                games = new ObservableCollection<Game>();
                db.Games.Load();
                db.Users.Load();
                User user = db.Users.Find(App.CurrentUser.Id);
                foreach (var game in user.Games)
                {
                    games.Add(game);
                    countOfGames++;
                }
                CountOfUserGamesTextBox.Text = "Количество игр на аккаунте: " + countOfGames;
                DataGridUserGames.ItemsSource = games;
            }
        }

        private void RefreshUserGames_Click(object sender, RoutedEventArgs e)
        {
            ShowUserGames();
        }

        private void GoToChallenges_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow parentWindow = (HomeWindow)Window.GetWindow((DependencyObject)sender);
            if (parentWindow != null)
            {
                parentWindow.NavigationMenu.SelectedIndex = 3;
            }
        }

        private void GoToNotes_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow parentWindow = (HomeWindow)Window.GetWindow((DependencyObject)sender);
            if (parentWindow != null)
            {
                parentWindow.NavigationMenu.SelectedIndex = 4;
            }
        }

        private void LeaveComment_Click(object sender, RoutedEventArgs e)
        {
            LeaveCommentWindow leaveCommentWindow = new LeaveCommentWindow(this);
            hideAllRectangle.Opacity = 0.4;
            DataGridUserGames.Opacity = 0.6;
            leaveCommentWindow.ShowDialog();
        }

        private void DeleteGame_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridUserGames.SelectedItem != null)
            {
                Game selectedGame = (Game)DataGridUserGames.SelectedItem;
                using (AppDbContext db = new AppDbContext())
                {
                    db.Games.Load();
                    Game game = db.Games.Find(selectedGame.Id);
                    User user = db.Users.Find(App.CurrentUser.Id);
                    user.Games.Remove(game);
                    db.SaveChanges();
                    ShowUserGames();
                }
            }
            else
            {
                MessageBox.Show("Сначала нужно выбрать игру", "Ошибка");
            }
        }

        private void OpenChallengeWindow_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            using (AppDbContext db = new AppDbContext())
            {
                User tempUser = db.Users.Find(App.CurrentUser.Id);
                if (tempUser.UserChallenge.Where(p=>p.IsCompleted == false).Count() == 0) { flag = false; }
                //foreach (var ch in tempUser.UserChallenge)
                //{
                //    if (ch.IsCompleted) { flag = false; }
                //}
            }
            if (!flag)
            {
                MessageBox.Show("У Вас нет активных вызовов", "Упс..");
            }
            else
            
            {
                AcceptedChallengeWindow challengeWindow = new AcceptedChallengeWindow(this);
                hideAllRectangle.Opacity = 0.4;
                DataGridUserGames.Opacity = 0.6;
                challengeWindow.ShowDialog();
            }
        }
    }
}
