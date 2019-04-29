using GamingAssistant.Models.ComponentsModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GamingAssistant.UserContorls
{
    /// <summary>
    /// Логика взаимодействия для Challenges.xaml
    /// </summary>
    public partial class Challenges : UserControl
    {
        public List<Challenge> challenges;
        public Challenges()
        {
            InitializeComponent();
            DataGridChallenges.ItemsSource = null;
            ShowChallenges();
        }

        private List<Challenge> GetChallenges()
        {
            return new List<Challenge>()
        {
        new Challenge("Убей 100 врагов", "Нужно убить 100 врагов в игре Fortnite", new User(){Username="Vadim"}, new Game("FORTNITE",5.0,"/Resources/GamesImages/fortnite.jpg")),
        new Challenge("Убей 200 врагов", "Нужно убить 100 врагов в игре PUBG", new User(){Username="Nikita"}, new Game("PUBG",5.0,"/Resources/GamesImages/pubg.jpeg"))
        };
        }

        private void AddNewChallengeClick(object sender, RoutedEventArgs e)
        {
            CreateChallengeWindow createChallengeWindow = new CreateChallengeWindow();
            createChallengeWindow.ShowDialog();
        }

        public void ShowChallenges()
        {
            challenges = GetChallenges();
            if (challenges.Count > 0)
                DataGridChallenges.ItemsSource = challenges;
        }
    }
}
