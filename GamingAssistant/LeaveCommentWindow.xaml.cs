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
    /// Логика взаимодействия для LeaveCommentWindow.xaml
    /// </summary>
    public partial class LeaveCommentWindow : Window
    {
        Home homeWindow;
        public LeaveCommentWindow()
        {
            InitializeComponent();
        }

        public LeaveCommentWindow(Home home)
        {
            homeWindow = home;
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

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            homeWindow.hideAllRectangle.Opacity = 0;
            homeWindow.DataGridUserGames.Opacity = 1;
            Close();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (textOfComment.Text == String.Empty)
            {
                MessageBox.Show("Отзыв не может быть пустым", "Упс..");
                textOfComment.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (textOfComment.Text.Length < 10)
            {
                MessageBox.Show("Отзыв слишком короткий. Минимальная длина 10 символов", "Упс..");
            }
            else
            {
                textOfComment.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");
                using (AppDbContext db = new AppDbContext())
                {
                    db.Games.Load();
                    db.Users.Load();
                    Game selectedgame = db.Games.Local.Single(p => p.Name.Equals(ComboBoxGames.SelectedItem.ToString()));
                    User selectedUser = db.Users.Local.Single(p => p.Id.Equals(App.CurrentUser.Id));
                    Comment createdComment = new Comment { Text = textOfComment.Text, User = selectedUser, Game = selectedgame };
                    db.Comments.Add(createdComment);

                    User thiUser = db.Users.Find(App.CurrentUser.Id);
                    Log log = new Log() { Time = DateTime.Now, Action = "Пользователь " + thiUser.Username + " оставил комментарий: " + createdComment.Text + " к игре " + selectedgame.Name };
                    db.Logs.Add(log);
                    db.SaveChanges();
                }
                MessageBox.Show("Комментарий отправлен!", "Успешно");
                textOfComment.Text = String.Empty;
            }
        }

        private void RangeDragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }   
}
