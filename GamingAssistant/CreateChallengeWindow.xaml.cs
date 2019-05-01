using GamingAssistant.Models.ComponentsModel;
using static GamingAssistant.UserContorls.Challenges;
using GamingAssistant.UserContorls;
using System;
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
            ComboBoxGames.SelectedIndex = 0;
            //var games = GetGames();
            //if (games.Count > 0)
            //    ComboBoxGames.ItemsSource = games;
        }
        public CreateChallengeWindow(Challenges ch)
        {
            challengesWindow = ch;
            InitializeComponent();
            //ComboBoxGames.SelectedIndex = 0;
            //var games = GetGames();
            //if (games.Count > 0)
            //    ComboBoxGames.ItemsSource = games;
        }

        //private List<Game> GetGames()
        //{
        //    return new List<Game>()
        //{
        //new Game("GTA 5", 5.0,"/Resources/GamesImages/gta.jpg"),
        //new Game("CS: GO", 4.8,"/Resources/GamesImages/csgo.jpg"),
        //new Game("Fortnite", 5.0,"/Resources/GamesImages/fortnite.jpg"),
        //new Game("Dota 2", 4.1,"/Resources/GamesImages/dota2.jpeg"),
        //new Game("Paladins", 3.5,"/Resources/GamesImages/paladins.jpeg")
        //};
        //}

        private void WindowClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddNewChallengeClick(object sender, RoutedEventArgs e)
        {
            //Challenge createdChallenge = new Challenge(titleOfCreatedChallenge.Text, textOfCreatedChallenge.Text, new User() { Username = "Вадим" }, new Game(ComboBoxGames.SelectedItem.ToString(), 5.0, "/Resources/GamesImages/default.jpg"));
            //challengesWindow.challenges.Add(createdChallenge);
            ////challengesWindow.DataGridChallenges.ItemsSource = null;
            ////challengesWindow.DataGridChallenges.ItemsSource = challengesWindow.challenges;
            Close();
        }
    }
}
