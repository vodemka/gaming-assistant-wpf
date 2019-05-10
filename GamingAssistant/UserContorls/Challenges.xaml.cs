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
        public Challenges()
        {
            using (AppDbContext db = new AppDbContext())
            {
                InitializeComponent();
                //InitChallenges();
                challenges = new ObservableCollection<Challenge>(); 
                db.Users.Load();
                db.Games.Load();
                db.Challenges.Load();
                foreach (var challenge in db.Challenges)
                {
                    challenges.Add(challenge);
                }
                DataGridChallenges.ItemsSource = challenges;
            }
        }
        private void InitChallenges()
        {
            using (AppDbContext db = new AppDbContext())
            {
                User user2 = new User() { Username = "vdfs", Hash = "fdfd", Salt = "fdfsww" };
                Challenge ch2 = new Challenge() { Title = "Test2", Text = "Test text of the challenge", Creator = user2 };
                db.Challenges.Add(ch2);
                db.Entry(ch2).State = EntityState.Detached;
                db.SaveChanges();
            }
        }
        //private ObservableCollection<Challenge> GetChallenges()
        //{
        //    return new ObservableCollection<Challenge>()
        //{
        //new Challenge("Киллер", "Нужно убить 100 врагов в игре Fortnite", new User(){Username="Вадим"}, new Game("FORTNITE",5.0,"/Resources/GamesImages/fortnite.jpg")),
        //new Challenge("Потрошитель", "Нужно убить 200 врагов в игре PUBG", new User(){Username="Никита"}, new Game("PUBG",5.0,"/Resources/GamesImages/pubg.jpeg")),
        //new Challenge("Золотая лихорадка", "Нужно создать 32 золотых блока в игре Minecraft", new User(){Username="Вероника"}, new Game("MINECRAFT",5.0,"/Resources/GamesImages/minecraft.png")),
        //new Challenge("Футболист", "Нужно забить 7 голов сопернику в игре Rocket League", new User(){Username="Саша"}, new Game("ROCKET LEAGUE",5.0,"/Resources/GamesImages/rocket.jpg")),
        //    };
        //}

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
                        MessageBox.Show("У Вас уже есть активный вызов", "Ошибка");
                        DataGridChallenges.SelectedItem = null;
                    } else
                    if (isEverComplete)
                    {
                        MessageBox.Show("Вы уже выполняли данный вызов!", "Упс..");
                        DataGridChallenges.SelectedItem = null;
                    } else
                    if (isCreatedByUser)
                    {
                        MessageBox.Show("Вы не можете принять созданый Вами вызов", "Ошибка");
                        DataGridChallenges.SelectedItem = null;
                    }
                    else
                    {
                        UserChallenge userChallenge = new UserChallenge() { User = user, Challenge = challenge, AcceptTime=DateTime.Now };
                        db.UserChallenges.Add(userChallenge);
                        db.SaveChanges();
                        MessageBox.Show("Отлично! Вызов добавлен", "Успех");
                        DataGridChallenges.SelectedItem = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("Сначала нужно выбрать вызов", "Ошибка");
            }
        }
    }
}