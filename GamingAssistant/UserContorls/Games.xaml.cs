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
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : UserControl
    {
        public Games()
        {
            InitializeComponent();
            var games = GetGames();
            if (games.Count > 0)
                ListViewGames.ItemsSource = games;
        }

        private List<Game> GetGames()
        {
            return new List<Game>()
        {
        new Game("GTA 5", 4.55,"/Resources/GamesImages/gta.jpg"),
        new Game("CS: GO", 4.4,"/Resources/GamesImages/csgo.jpg"),
        new Game("Fortnite", 5.0,"/Resources/GamesImages/fortnite.jpg"),
        new Game("Dota 2", 4.1,"/Resources/GamesImages/dota2.jpeg"),
        new Game("Paladins", 3.5,"/Resources/GamesImages/paladins.jpeg"),
        new Game("PUBG", 4.0,"/Resources/GamesImages/pubg.jpeg"),
        new Game("Rocket League", 3.9,"/Resources/GamesImages/rocket.jpg"),
        new Game("PAY DAY", 2.7,"/Resources/GamesImages/payday.jpg"),
        new Game("Minecraft", 5,"/Resources/GamesImages/minecraft.png"),
        new Game("Dota 2", 4.1,"/Resources/GamesImages/dota2.jpeg"),
        new Game("Paladins", 3.5,"/Resources/GamesImages/paladins.jpeg"),
        new Game("PUBG", 4.0,"/Resources/GamesImages/pubg.jpeg"),
        new Game("Rocket League", 3.9,"/Resources/GamesImages/rocket.jpg"),
        new Game("PAY DAY", 2.7,"/Resources/GamesImages/payday.jpg"),
        new Game("Minecraft", 5,"/Resources/GamesImages/minecraft.png")
        };
        }
    }
}
