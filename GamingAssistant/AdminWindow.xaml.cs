using GamingAssistant.Models.ComponentsModel;
using System;
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
    }
}
