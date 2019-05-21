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
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            regLoginTextBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");
            regPasswordBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");
            regConfirmPasswordBox.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");
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

                if (Validation.TryValidateObject(registerModel, regLoginTextBox, regPasswordBox, regConfirmPasswordBox))
                {
                    SaltedHash saltedHash = new SaltedHash(password);
                    bool isAdmin = username == "Admin";

                    using (AppDbContext db = new AppDbContext())
                    {
                        var sameUser = db.Users.FirstOrDefault(u => u.Username == username);
                        if (sameUser == null && !isAdmin)
                        {
                            User user = new User()
                            {
                                Username = username,
                                Salt = saltedHash.Salt,
                                Hash = saltedHash.Hash,
                            };
                            db.Users.Add(user);

                            Log log = new Log() { Time = DateTime.Now, Action = "Пользователь " + user.Username + " зарегистрировался" };
                            db.Logs.Add(log);
                            db.SaveChanges();
                            ShowLoginWindow();
                        }
                        else
                        if (sameUser == null && isAdmin)
                        {
                            User user = new User()
                            {
                                Username = username,
                                Salt = saltedHash.Salt,
                                Hash = saltedHash.Hash,
                                IsAdmin = isAdmin
                            };
                            db.Users.Add(user);

                            Log log = new Log() { Time = DateTime.Now, Action = "Аккаунт админа зарегистрирован" };
                            db.Logs.Add(log);
                            db.SaveChanges();
                            ShowLoginWindow();
                        }
                        else
                        {
                            regLoginTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                            regLoginTextBox.ToolTip = new ToolTip() { Content = "Это имя пользователя уже занято" };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
            }
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
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

        private void RangeDragWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Grid_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Register();
            }
        }
    }
}
