using GamingAssistant.Models.ComponentsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            ShowLog();
        }

        private void WindowClose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowLog()
        {
            using (AppDbContext db = new AppDbContext())
            {
                LogList.ItemsSource = db.Logs.OrderByDescending(p=>p.Time).ToList();
            }
        }

        private void ChangeAccount(object sender, RoutedEventArgs e)
        {
            ShowLoginWindow();
        }

        private void ShowLoginWindow()
        {
            AuthentificationWindow authentification = new AuthentificationWindow();
            Close();
            //------------LOADER---------------
            Thread myThread = new Thread(new ThreadStart(ShowLoader));
            myThread.SetApartmentState(ApartmentState.STA);
            myThread.Start();
            Thread.Sleep(1000);
            myThread.Abort();
            authentification.Show();
            //---------------------------------
        }

        private static void ShowLoader()
        {
            Loader loader = new Loader();
            loader.ShowDialog();
            loader.Close();
        }
    }
}
