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
    /// Логика взаимодействия для AuthentificationWindow.xaml
    /// </summary>
    public partial class AuthentificationWindow : Window
    {
        public AuthentificationWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Close();
            Thread myThread = new Thread(new ThreadStart(ShowLoader));
            myThread.SetApartmentState(ApartmentState.STA);
            myThread.Start(); // запускаем поток
            Thread.Sleep(1500);
            myThread.Abort();
            registerWindow.Show();
        }

        private static void ShowLoader()
        {
            Loader loader = new Loader();
            loader.ShowDialog();
            loader.Close();
        }
    }
}
