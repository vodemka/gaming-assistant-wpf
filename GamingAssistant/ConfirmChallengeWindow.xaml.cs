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
using System.Diagnostics;
using System.Windows.Navigation;

namespace GamingAssistant
{
    /// <summary>
    /// Логика взаимодействия для ConfirmChallengeWindow.xaml
    /// </summary>
    public partial class ConfirmChallengeWindow : Window
    {
        ActiveChallenges activeChallenges;
        UserChallenge uch;
        public ConfirmChallengeWindow()
        {
            InitializeComponent();
        }

        public ConfirmChallengeWindow(ActiveChallenges ac, UserChallenge userChallenge)
        {
            activeChallenges = ac;
            uch = userChallenge;
            InitializeComponent();
            string Title = "", Text = "";
            string DateOfAccept = "";
            string DateOfConfirm = "";
            string ProofLink = "";
            bool flag = true;
            
            using (AppDbContext db = new AppDbContext())
            {
                UserChallenge uch2 = db.UserChallenges.Find(uch.Id);
                Challenge ch = db.Challenges.Find(uch2.Challenge.Id);
                Game game = db.Games.Find(ch.Game.Id);
                ProofLink = uch2.ProofLink;
                Title = ch.Title;
                Text = ch.Text;
                if (uch2.AcceptTime != null)
                {
                    DateOfAccept = uch.AcceptTime.ToString();
                }
                else
                {
                    DateOfAccept = "--";
                }

                if (uch2.ConfirmTime != null)
                {
                    DateOfConfirm = uch2.ConfirmTime.ToString();
                }
                else
                {
                    DateOfConfirm = "--";
                }

                if (uch2.ProofLink == null)
                {
                    var x = activeChallengeProofLink.Inlines.FirstInline.TextDecorations = TextDecorations.Strikethrough;
                    activeChallengeProofLink.Inlines.FirstInline.ToolTip = "Скриншот еще не загружен";
                    flag = false;
                }
            }
            activeChallengeTitle.Content = Title;
            activeChallengeText.Text = Text;
            activeChallengeDate.Text = DateOfAccept;
            activeChallengeConfirmDate.Text = DateOfConfirm;
            if (flag)
            {
                activeChallengeProofLink.NavigateUri = new Uri(ProofLink);
            }
        }

        private void ConfirmChallenge_Click(object sender, RoutedEventArgs e)
        {
            bool flag = true, flagIsOwner = true, flagIsReady = true;
            using (AppDbContext db = new AppDbContext())
            {
                UserChallenge userChallenge = db.UserChallenges.Find(uch.Id);
                if (userChallenge.IsCompleted) { flag = false; }

                User user = db.Users.Find(App.CurrentUser.Id);
                if (user.Id == userChallenge.UserId) { flagIsOwner = false; }

                flagIsReady = userChallenge.IsUserReady;
            }

            if (!flag)
            {
                MessageBox.Show("Этот вызов уже подтвержден. Обновите список вызовов", "Упс..");
            }
            else

            if (!flagIsOwner)
            {
                MessageBox.Show("Вы не можете подтвердить свой же вызов", "Упс..");
            }
            else

            if (!flagIsReady)
            {
                MessageBox.Show("Пользователь еще выполняет этот вызов");
            }
            else
            {
                using (AppDbContext db = new AppDbContext())
                {
                    UserChallenge userChallenge = db.UserChallenges.Find(uch.Id);
                    userChallenge.IsCompleted = true;
                    db.Entry(userChallenge).State = EntityState.Modified;
                    Challenge currentChallenge = db.Challenges.Find(userChallenge.Challenge.Id);
                    currentChallenge.CountOfComplete++;
                    db.Entry(currentChallenge).State = EntityState.Modified;

                    User thiUser = db.Users.Find(App.CurrentUser.Id);
                    Log log = new Log() { Time = DateTime.Now, Action = "Пользователь " + thiUser.Username + " подтвердил выполнение вызова игроком " + userChallenge.User.Username };
                    db.Logs.Add(log);
                    db.SaveChanges();
                }
                MessageBox.Show("Вы подтвердили вызов, спасибо!", "Отлично");
                activeChallenges.ShowActiveChallenges();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RangeDragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
