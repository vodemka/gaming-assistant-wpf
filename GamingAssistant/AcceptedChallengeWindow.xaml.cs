using GamingAssistant.Models.ComponentsModel;
using GamingAssistant.UserContorls;
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
using System.Windows.Shapes;

namespace GamingAssistant
{
    /// <summary>
    /// Логика взаимодействия для AcceptedChallengeWindow.xaml
    /// </summary>
    public partial class AcceptedChallengeWindow : Window
    {
        Home homeWindow;
        public AcceptedChallengeWindow()
        {
            InitializeComponent();
        }

        public AcceptedChallengeWindow(Home home)
        {
            homeWindow = home;
            InitializeComponent();
            string Title = "", Text = "", Game = "";
            string Path = "pack://application:,,,";
            string DateOfAccept = "";
            string DateOfConfirm = "";
            using (AppDbContext db = new AppDbContext())
            {
                User user = db.Users.Find(App.CurrentUser.Id);
                UserChallenge uch = user.UserChallenge.Where(p=>p.IsCompleted == false).First();
                Challenge ch = db.Challenges.Find(uch.Challenge.Id);
                Game game = db.Games.Find(ch.Game.Id);
                Title = ch.Title;
                Text = ch.Text;
                Path = Path + game.Image;
                Game = game.Name;
                if (uch.AcceptTime != null)
                {
                    DateOfAccept = uch.AcceptTime.ToString();
                }
                else
                {
                    DateOfAccept = "None";
                }

                if (uch.ConfirmTime != null)
                {
                    DateOfConfirm = uch.ConfirmTime.ToString();
                }
            }
            var uri = new Uri(Path);
            var bitmap = new BitmapImage(uri);
            activeChallengeTitle.Content = Title;
            activeChallengeText.Text = Text;
            activeChallengeGameImage.Source = bitmap;
            activeChallengeGame.Text = Game;
            activeChallengeDate.Text = DateOfAccept;
        }
        
        private void RangeDragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            homeWindow.hideAllRectangle.Opacity = 0;
            homeWindow.DataGridUserGames.Opacity = 1;
            Close();
        }

        private void UserReadyWithChallenge_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true;
            using (AppDbContext db = new AppDbContext())
            {
                User user = db.Users.Find(App.CurrentUser.Id);
                UserChallenge uch = user.UserChallenge.Where(p=>p.IsCompleted==false).First();
                if (uch.IsUserReady == true)
                {
                    flag = false;
                }
            }
            if (flag)
            {

                if (proofLinkTextBox.Text == String.Empty)
                {
                    MessageBox.Show("Заполните поле!", "Ошибка");
                    proofLinkTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    proofLinkTextBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");
                    using (AppDbContext db = new AppDbContext())
                    {
                        User user = db.Users.Find(App.CurrentUser.Id);
                        UserChallenge uch = user.UserChallenge.Where(p=>p.IsCompleted == false).First();
                        uch.ConfirmTime = DateTime.Now;
                        uch.ProofLink = proofLinkTextBox.Text;
                        uch.IsUserReady = true;
                        db.Entry(uch).State = EntityState.Modified;

                        User thiUser = db.Users.Find(App.CurrentUser.Id);
                        Log log = new Log() { Time = DateTime.Now, Action = "Пользователь " + thiUser.Username + " отправил подтверждение вызова: " + uch.Challenge.Text };
                        db.Logs.Add(log);
                        db.SaveChanges();
                    }
                    MessageBox.Show("Вы отправили подтверждение на рассмотрение!", "Отлично");
                }
            }
            else
            {
                MessageBox.Show("Вы уже подтверждали", "Ошибка");
            }
        }
    }
}
