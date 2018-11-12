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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sqlDB.EditControls
{
    /// <summary>
    /// Логика взаимодействия для create.xaml
    /// </summary>
    public partial class create : UserControl
    {
        public create()
        {
            InitializeComponent();
        }

        private void backBut_Click(object sender, RoutedEventArgs e)
        {
            pageContent.Children.Clear();
            UserControl usc = null;

            usc = new dbView("drivers");
            pageContent.Children.Add(usc);
        }
    }
}
