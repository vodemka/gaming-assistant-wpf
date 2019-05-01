using GamingAssistant.Models.ComponentsModel;
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
    /// Логика взаимодействия для Games.xaml
    /// </summary>
    public partial class Games : UserControl
    {
        AppDbContext db;
        public Games()
        {
            InitializeComponent();
            db = new AppDbContext();
            //InitGames();
            db.Games.Load();
            ListViewGames.ItemsSource = db.Games.Local;
        }

        private void InitGames()
        {
            Game game1 = new Game() { Name = "GTA 5", Rating = 4.4, Image = "/Resources/GamesImages/gta.jpg" };
            Game game2 = new Game() { Name = "CS: GO", Rating = 4.3, Image = "/Resources/GamesImages/csgo.jpg" };
            Game game3 = new Game() { Name = "Fortnite", Rating = 5.0, Image = "/Resources/GamesImages/fortnite.jpg" };
            Game game4 = new Game() { Name = "Minecraft", Rating = 5.0, Image = "/Resources/GamesImages/dota2.jpeg" };
            Game game5 = new Game() { Name = "PUBG", Rating = 4.0, Image = "/Resources/GamesImages/pubg.jpeg" };
            Game game6 = new Game() { Name = "Rocket League", Rating = 3.9, Image = "/Resources/GamesImages/rocket.jpg" };
            Game game7 = new Game() { Name = "PAY DAY", Rating = 2.7, Image = "/Resources/GamesImages/payday.jpg" };
            Game game8 = new Game() { Name = "Minecraft", Rating = 5.0, Image = "/Resources/GamesImages/minecraft.png" };
            Game game9 = new Game() { Name = "Paladins", Rating = 3.4, Image = "/Resources/GamesImages/paladins.jpeg" };
            Game game10 = new Game() { Name = "FIFA 19", Rating = 4.2, Image = "/Resources/GamesImages/fifa.jpg" };
            Game game11 = new Game() { Name = "Assassin's Creed", Rating = 4.4, Image = "/Resources/GamesImages/assassin.jpeg" };
            Game game12 = new Game() { Name = "Clash Of Clans", Rating = 5.0, Image = "/Resources/GamesImages/clash.jpg" };
            Game game13 = new Game() { Name = "League Of Legends", Rating = 5.0, Image = "/Resources/GamesImages/lol.jpg" };
            Game game14 = new Game() { Name = "Metro Exodus", Rating = 5.0, Image = "/Resources/GamesImages/metro.jpeg" };
            Game game15 = new Game() { Name = "Witcher", Rating = 4.0, Image = "/Resources/GamesImages/witcher.jpeg" };
            db.Games.Add(game1);
            db.Games.Add(game2);
            db.Games.Add(game3);
            db.Games.Add(game4);
            db.Games.Add(game5);
            db.Games.Add(game6);
            db.Games.Add(game7);
            db.Games.Add(game8);
            db.Games.Add(game9);
            db.Games.Add(game10);
            db.Games.Add(game11);
            db.Games.Add(game12);
            db.Games.Add(game13);
            db.Games.Add(game14);
            db.Games.Add(game15);
            db.SaveChanges();
        }
        //private List<Game> GetGames()
        //{
        //    return new List<Game>()
        //{
        //new Game("GTA 5", 4.55,"/Resources/GamesImages/gta.jpg"),
        //new Game("CS: GO", 4.4,"/Resources/GamesImages/csgo.jpg"),
        //new Game("Fortnite", 5.0,"/Resources/GamesImages/fortnite.jpg"),
        //new Game("Dota 2", 4.1,"/Resources/GamesImages/dota2.jpeg"),
        //new Game("Paladins", 3.5,"/Resources/GamesImages/paladins.jpeg"),
        //new Game("PUBG", 4.0,"/Resources/GamesImages/pubg.jpeg"),
        //new Game("Rocket League", 3.9,"/Resources/GamesImages/rocket.jpg"),
        //new Game("PAY DAY", 2.7,"/Resources/GamesImages/payday.jpg"),
        //new Game("Minecraft", 5,"/Resources/GamesImages/minecraft.png"),
        //new Game("Dota 2", 4.1,"/Resources/GamesImages/dota2.jpeg"),
        //new Game("Paladins", 3.5,"/Resources/GamesImages/paladins.jpeg"),
        //new Game("PUBG", 4.0,"/Resources/GamesImages/pubg.jpeg"),
        //new Game("Rocket League", 3.9,"/Resources/GamesImages/rocket.jpg"),
        //new Game("PAY DAY", 2.7,"/Resources/GamesImages/payday.jpg"),
        //new Game("Minecraft", 5,"/Resources/GamesImages/minecraft.png")
        //};
        //}
    }
}
