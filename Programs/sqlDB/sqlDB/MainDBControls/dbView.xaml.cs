using System;
using System.Collections.Generic;
using System.Data;
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

namespace sqlDB.MainDBControls
{
    /// <summary>
    /// Логика взаимодействия для driversView.xaml
    /// </summary>
    public partial class dbView : UserControl
    {
        public dbView(string table)
        {
            InitializeComponent();

            DBConnect.LoadToDataGrid(table, dataGrid);

        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            DBConnect.UpdateDataGrid(dataGrid);
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            int parse = dataGrid.SelectedIndex;
            DataRowView rowView = dataGrid.SelectedValue as DataRowView;
            
            MessageBox.Show(parse.ToString() + rowView[0].ToString());
        }
    }
}
