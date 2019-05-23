using BespokeFusion;
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
    /// Логика взаимодействия для Notes.xaml
    /// </summary>
    public partial class Notes : UserControl
    {
        IEnumerable<Note> notes = new List<Note>();
        public string ChangedText = "";
        public Notes()
        {
            InitializeComponent();
            ShowNotes();
        }

        private void SaveTextChanges_Click(object sender, RoutedEventArgs e)
        {
            var note = (Note)((Button)sender).Tag;
            using (AppDbContext db = new AppDbContext())
            {
                Note selectedNote = db.Notes.Find(note.Id);
                selectedNote.Text = ChangedText;
                db.Entry(selectedNote).State = EntityState.Modified;
                db.SaveChanges();
            }
            MaterialMessageBox.Show("Заметка измена","Успех");
            ShowNotes();
        }

        private void DeleteNote_Click(object sender, RoutedEventArgs e)
        {
            var note = (Note)((Button)sender).Tag;
            using (AppDbContext db = new AppDbContext())
            {
                Note selectedNote = db.Notes.Find(note.Id);
                db.Notes.Remove(selectedNote);
                db.SaveChanges();
            }
            MaterialMessageBox.Show("Заметка удалена","Успех");
            ShowNotes();
        }

        public void ShowNotes()
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Notes.Load();
                db.Games.Load();
                notes = db.Notes.Local.Where(p => p.UserId == App.CurrentUser.Id);
                ListOfNotes.ItemsSource = notes.Reverse();
            }
        }

        private void SortByGame_Click(object sender, RoutedEventArgs e)
        {
            using (AppDbContext db = new AppDbContext())
            {
                db.Notes.Load();
                db.Games.Load();
                notes = db.Notes.Local.Where(p => p.UserId == App.CurrentUser.Id).OrderBy(p=>p.Game.Name);
                ListOfNotes.ItemsSource = notes;
            }
        }

        private void AddNewNote_Click(object sender, RoutedEventArgs e)
        {
            AddNewNoteWindow addNewNoteWindow = new AddNewNoteWindow(this);
            addNewNoteWindow.ShowDialog();
        }

        private void TextOfNote_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = (TextBox)sender;
            ChangedText = text.Text;
        }
    }
}
