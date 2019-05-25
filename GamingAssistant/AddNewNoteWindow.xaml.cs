using GamingAssistant.Models.ComponentsModel;
using GamingAssistant.UserContorls;
using System;
using BespokeFusion;
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
    public partial class AddNewNoteWindow : Window
    {
        Notes notesWindow;
        public AddNewNoteWindow()
        {
            InitializeComponent();
        }

        public AddNewNoteWindow(Notes notes)
        {
            notesWindow = notes;
            InitializeComponent();
            FillComboBoxGames();
        }

        private void FillComboBoxGames()
        {
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

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            if (textOfNote.Text == String.Empty)
            {
                MaterialMessageBox.Show("Вы хотите добавить пустую заметку", "Упс..");
            }
            else if (ComboBoxGames.SelectedItem == null)
            {
                MaterialMessageBox.Show("Сначала нужно добавить игру", "Упс..");
            }
            else
            {
                using (AppDbContext db = new AppDbContext())
                {
                    db.Games.Load();
                    db.Users.Load();
                    Game selectedgame = db.Games.Local.Single(p => p.Name.Equals(ComboBoxGames.SelectedItem.ToString()));
                    User selectedUser = db.Users.Local.Single(p => p.Id.Equals(App.CurrentUser.Id));
                    Note newNote = new Note() { Text = textOfNote.Text, Game = selectedgame, User = selectedUser };
                    db.Notes.Add(newNote);
                    db.SaveChanges();
                }
                MaterialMessageBox.Show("Заметка успешно добавлена", "Отлично");
                notesWindow.ShowNotes();
                Close();
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
    }
}
