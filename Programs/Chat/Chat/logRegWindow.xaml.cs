using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для logRegWindow.xaml
    /// </summary>
    public partial class logRegWindow : Window
    {
        public logRegWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text;
            string password = passBox.Password;

            bool res = DBConnect.LoginFunc(login, password);
            if (res)
            {
                DBConnect.user = login;
                Window mainWin = new Client();
                mainWin.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
            }
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = regLoginBox.Text;
            string password = regPassBox.Password;
            string email = regEmailBox.Text;

            if (IsValidEmailAddress(email) == false)
                MessageBox.Show("Неверный адресс электронной почты");
            else
            {
                try
                {
                    DBConnect.RegFunc(login, password, email);
                    MessageBox.Show("Вы были успешно зарегистрированы");
                    loginBox.Text = login;
                    regLoginBox.Text = string.Empty;
                    regPassBox.Password = string.Empty;
                    regEmailBox.Text = string.Empty;
                }
                catch
                {
                    MessageBox.Show("Пользователь с данным логином или email уже существует.");
                    regPassBox.Clear();
                }
            }
        }

        public static bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }
}
