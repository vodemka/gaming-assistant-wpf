using GamingAssistant.Models.ComponentsModel;
using System;
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
    /// <summary>
    /// Логика взаимодействия для Challenges.xaml
    /// </summary>
    public partial class Challenges : UserControl
    {
        public ObservableCollection<Challenge> challenges;
        AppDbContext db;
        public Challenges()
        {
            InitializeComponent();
            db = new AppDbContext();
            //InitChallenges();
            challenges = new ObservableCollection<Challenge>();
            //challenges =
            db.Challenges.Load();
                DataGridChallenges.ItemsSource = db.Challenges.Local.ToBindingList();
            //ShowChallenges();
        }
        private void InitChallenges()
        {
            Challenge ch1 = new Challenge() { Title="Test", Text="Test text of the challenge", Creator=App.CurrentUser};
                db.Challenges.Add(ch1);
                db.SaveChanges();
        }
        //private ObservableCollection<Challenge> GetChallenges()
        //{
        //    return new ObservableCollection<Challenge>()
        //{
        //new Challenge("Киллер", "Нужно убить 100 врагов в игре Fortnite", new User(){Username="Вадим"}, new Game("FORTNITE",5.0,"/Resources/GamesImages/fortnite.jpg")),
        //new Challenge("Потрошитель", "Нужно убить 200 врагов в игре PUBG", new User(){Username="Никита"}, new Game("PUBG",5.0,"/Resources/GamesImages/pubg.jpeg")),
        //new Challenge("Золотая лихорадка", "Нужно создать 32 золотых блока в игре Minecraft", new User(){Username="Вероника"}, new Game("MINECRAFT",5.0,"/Resources/GamesImages/minecraft.png")),
        //new Challenge("Футболист", "Нужно забить 7 голов сопернику в игре Rocket League", new User(){Username="Саша"}, new Game("ROCKET LEAGUE",5.0,"/Resources/GamesImages/rocket.jpg")),
        //new Challenge("Киллер", "Нужно убить 100 врагов в игре Fortnite", new User(){Username="Вадим"}, new Game("FORTNITE",5.0,"/Resources/GamesImages/fortnite.jpg")),
        //new Challenge("Потрошитель", "Нужно убить 200 врагов в игре PUBG", new User(){Username="Никита"}, new Game("PUBG",5.0,"/Resources/GamesImages/pubg.jpeg")),
        //new Challenge("Золотая лихорадка", "Нужно создать 32 золотых блока в игре Minecraft", new User(){Username="Вероника"}, new Game("MINECRAFT",5.0,"/Resources/GamesImages/minecraft.png")),
        //new Challenge("Футболист", "Нужно забить 7 голов сопернику в игре Rocket League", new User(){Username="Саша"}, new Game("ROCKET LEAGUE",5.0,"/Resources/GamesImages/rocket.jpg"))
        //    };
        //}

        private void AddNewChallengeClick(object sender, RoutedEventArgs e)
        {
            CreateChallengeWindow createChallengeWindow = new CreateChallengeWindow(this);
            createChallengeWindow.ShowDialog();
        }

        public void ShowChallenges()
        {
            //challenges = GetChallenges();
            //if (challenges.Count > 0)
            //    DataGridChallenges.ItemsSource = challenges;
        }
    }
}
