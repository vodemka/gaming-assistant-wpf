using GamingAssistant.Models.ComponentsModel;
using GamingAssistant.UserContorls;
using System;
using BespokeFusion;
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
    /// Логика взаимодействия для AddNewGameWindow.xaml
    /// </summary>
    public partial class AddNewGameWindow : Window
    {
        Games gamesWindow;
        public AddNewGameWindow()
        {
            InitializeComponent();
        }

        public AddNewGameWindow(Games games)
        {
            gamesWindow = games;
            InitializeComponent();
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext db = new AppDbContext())
            {
                User user = db.Users.Find(App.CurrentUser.Id);
                bool isAlreadyExists = false;
                foreach (Game ga in db.Games)
                {
                    if (ga.Name == nameOfGame.Text || ga.Name.ToUpper() == nameOfGame.Text.ToUpper()) { isAlreadyExists = true; break; }
                    
                }
                if (isAlreadyExists)
                {
                    MaterialMessageBox.Show("Эта игра уже есть в библиотеке", "Ошибка");
                }
                else 
                if (nameOfGame.Text.Length < 2)
                {
                    MaterialMessageBox.Show("Название игры не может быть меньше 2 символов");
                    nameOfGame.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else 
                if (nameOfGame.Text.Length > 20)
                {
                    MaterialMessageBox.Show("Название игры не может быть больше 20 символов");
                    nameOfGame.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    nameOfGame.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");
                    Game newGame = new Game() { Name = nameOfGame.Text, Rating = ratingOfGame.Value, Image = "/Resources/GamesImages/default.jpg" };
                    db.Games.Add(newGame);

                    User thiUser = db.Users.Find(App.CurrentUser.Id);
                    Log log = new Log() { Time = DateTime.Now, Action = "Пользователь " + thiUser.Username + " добавил в общую библиотеку игру: " + newGame.Name };
                    db.Logs.Add(log);

                    db.SaveChanges();
                    MaterialMessageBox.Show("Игра успешно добавлена!", "Отлично");
                    nameOfGame.Text = String.Empty;
                    gamesWindow.ShowGames();
                }
            }
        }

        private void RangeDragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            gamesWindow.hideGamesRectangle.Opacity = 0;
            gamesWindow.ListViewGames.Opacity = 1;
        }
    }
}
