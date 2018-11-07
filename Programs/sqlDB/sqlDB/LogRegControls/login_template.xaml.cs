using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
using static sqlDB.DBConnect;

namespace sqlDB

{
    /// <summary>
    /// Логика взаимодействия для login_template.xaml
    /// </summary>
    public partial class login_template : UserControl
    {
        public login_template()
        {
            InitializeComponent();
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            pageContent.Children.Clear();
            pageContent.RowDefinitions.Clear();

            usc = new reg_page();
            pageContent.Children.Add(usc);

        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBlock.Text;
            string password = passwordBlock.Password;

            LoginFunc(login, password);

            loginBlock.Clear();
            passwordBlock.Clear();

            Window mainWin = new mainDbPage();
            mainWin.Show();
        }

        public void notifyWindowToClose()
        {
            Messenger.Default.Send<NotificationMessage>(
                new NotificationMessage(this, "CloseWindowsBoundToMe")
            );
        }
    }
}
