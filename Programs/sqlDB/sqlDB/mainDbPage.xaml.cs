using sqlDB.MainDBControls;
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

namespace sqlDB
{
    /// <summary>
    /// Логика взаимодействия для mainDbPage.xaml
    /// </summary>
    public partial class mainDbPage : Window
    {
        public mainDbPage()
        {
            InitializeComponent();
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            pageContent.Children.Clear();
            UserControl usc = null;

            if (((Button)sender as Button).Name == "driversViewBtn")
                usc = new dbView("drivers");
            if (((Button)sender as Button).Name == "carsViewBtn")
                usc = new dbView("cars");
            if (((Button)sender as Button).Name == "trailersViewBtn")
                usc = new dbView("trailers");
            if (((Button)sender as Button).Name == "cargoViewBtn")
                usc = new dbView("drivers");

            pageContent.Children.Add(usc);
        }
    }
}
