using BespokeFusion;
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
    /// Логика взаимодействия для OpenGameWindow.xaml
    /// </summary>
    public partial class OpenGameWindow : Window
    {
        Games gamesWindow;
        public Game selectedGame;
        public OpenGameWindow()
        {
            InitializeComponent();
        }

        public OpenGameWindow(Games games)
        {
            gamesWindow = games;
            InitializeComponent();
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            gamesWindow.hideGamesRectangle.Opacity = 0;
            gamesWindow.ListViewGames.Opacity = 1;
        }

        //CustomMaterialMessageBox msg = new CustomMaterialMessageBox
        //{
        //    TxtMessage = { Text = "Do you like white wine?", Foreground = Brushes.Black },
        //    TxtTitle = { Text = "This is too cool", Foreground = Brushes.Black },
        //    BtnOk = { Content = "Yes" },
        //    BtnCancel = { Content = "Noooo" },
        //    MainContentControl = { Background = Brushes.White },
        //    TitleBackgroundPanel = { Background = Brushes.White },
        //    BorderBrush = Brushes.Blue
        //};

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext db = new AppDbContext())
            {
                User user = db.Users.Find(App.CurrentUser.Id);
                Game game = db.Games.Find(selectedGame.Id);
                bool isAlreadyAdded = false;
                foreach (Game ga in user.Games)
                {
                    if (game == ga) { isAlreadyAdded = true; break; } 
                }
                if (isAlreadyAdded) {/* msg.Show();*/ MaterialMessageBox.Show( "Игра уже есть на вашем аккаунте!","Ошибка"); }
                else
                {
                    user.Games.Add(game);
                    db.SaveChanges();
                    MaterialMessageBox.Show( "Игра успешно добавлена!","Отлично");
                }
            }
        }

        private void RangeDragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}