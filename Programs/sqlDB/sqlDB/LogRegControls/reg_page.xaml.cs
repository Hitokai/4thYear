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

            sqlDB.DBConnect.RegFunc(login, password, email, fname, lname);

            loginBlock.Clear();
            passwordBlock.Clear();
            emailBlock.Clear();
            fnameBlock.Clear();
            lnameBlock.Clear();
        }
    }
}
