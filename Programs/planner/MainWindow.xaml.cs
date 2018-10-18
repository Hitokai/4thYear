using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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

namespace planner
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            logLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            regLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
        }

        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox currBox = (sender as TextBox);
            if (currBox.Text == "Логин" || currBox.Text == "Пароль" || currBox.Text == "Email" || currBox.Text == "Имя" || currBox.Text == "Фамилия")
            {
                currBox.Text = "";
                currBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void Box_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox currBox = (sender as TextBox);
            string currBoxName = (string)((TextBox)e.OriginalSource).Name;
            if (currBox.Text == "")
            {
                if(currBoxName == "loginRegBox" || currBoxName == "loginLogBox")
                    currBox.Text = "Логин";
                else if (currBoxName == "passwordRegBox" || currBoxName == "passwordLogBox")
                    currBox.Text = "Пароль";
                else if (currBoxName == "emailBox")
                    currBox.Text = "Email";
                else if (currBoxName == "fNameBox")
                    currBox.Text = "Имя";
                else if (currBoxName == "lNameBox")
                    currBox.Text = "Фамилия";

                currBox.Foreground = new SolidColorBrush(Colors.LightGray);
            }
        }
    }
}
