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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            regLoginTextBox.Focus();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }
        private void Register()
        {
            try
            {
                string username = regLoginTextBox.Text;
                string password = regPasswordBox.Password;
                string confirmPassword = regConfirmPasswordBox.Password;

                RegisterModel registerModel = new RegisterModel()
                {
                    Login = username,
                    Password = password,
                    ConfirmPassword = confirmPassword
                };

                MessageBox.Show(registerModel.Login);
                MessageBox.Show(registerModel.Password);

                if (Validation.TryValidateObject(registerModel, regLoginTextBox, regPasswordBox, regConfirmPasswordBox))

                {
                    //SaltedHash saltedHash = new SaltedHash(password);
                    //bool isTeacher = (bool)isTeacherCheckBox.IsChecked;

                    //using (AppDbContext db = new AppDbContext())
                    //{
                    //    var sameUser = db.Users.FirstOrDefault(u => u.Username == username);
                    //    if (sameUser == null)
                    //    {
                    User user = new User()
                    {
                        Username = username,
                        Password = password
                    };
                    OpenAuthentificationWindow();
                }
                //else
                //{
                //    regLoginTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                //    regLoginTextBox.ToolTip = new ToolTip() { Content = "This username is already taken" };
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            AuthentificationWindow authentification = new AuthentificationWindow();
            this.Close();
            Thread myThread = new Thread(new ThreadStart(ShowLoader));
            myThread.SetApartmentState(ApartmentState.STA);
            myThread.Start(); // запускаем поток
            Thread.Sleep(1500);
            myThread.Abort();
            authentification.Show();
        }

        private static void ShowLoader()
        {
            Loader loader = new Loader();
            loader.ShowDialog();
            loader.Close();
        }

        private void OpenAuthentificationWindow()
        {
            AuthentificationWindow authentification = new AuthentificationWindow();
            Close();
            Thread myThread = new Thread(new ThreadStart(ShowLoader));
            myThread.SetApartmentState(ApartmentState.STA);
            myThread.Start(); // запускаем поток
            Thread.Sleep(1500);
            myThread.Abort();
            authentification.Show();
        }
        //private void Validation()
        //{
        //    if (regis)
        //}
    }
}
