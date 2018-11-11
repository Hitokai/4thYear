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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sqlDB
{
    /// <summary>
    /// Логика взаимодействия для reg_page.xaml
    /// </summary>
    public partial class reg_page : UserControl
    {
        public reg_page()
        {
            InitializeComponent();
        }

        private void backToLogin_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            pageContent.Children.Clear();
            pageContent.RowDefinitions.Clear();

            usc = new login_template();
            pageContent.Children.Add(usc);
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBlock.Text;
            string password = passwordBlock.Password;
            string email = emailBlock.Text;
            string fname = fnameBlock.Text;
            string lname = lnameBlock.Text;

            if (IsValidEmailAddress(email) == false)
                MessageBox.Show("Неверный адресс электронной почты");
            else
            {
                try
                {
                    sqlDB.DBConnect.RegFunc(login, password, email, fname, lname);

                    UserControl usc = null;
                    pageContent.Children.Clear();
                    pageContent.RowDefinitions.Clear();

                    usc = new login_template();
                    pageContent.Children.Add(usc);
                }
                catch
                {
                    MessageBox.Show("Пользователь с данным логином или email уже существует.");
                    passwordBlock.Clear();
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
