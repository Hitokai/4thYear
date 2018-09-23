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
using static sudoku.sudokuAlg;

namespace sudoku
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            label.Content = "123";
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            Init(ref grid);
            Update(ref grid);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button button = new Button();
                    button.Name = "btn" + i.ToString() + j.ToString();
                    button.Content = grid[i, j].ToString();
                    button.Click += button_Click;
                    button.Background = new SolidColorBrush(Colors.Black) { Opacity = 0.2 };
                    gridBut.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                }
            }
            btnStart.IsEnabled = false;

        }

        public static void Numbers(ref int[,] grid)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    s += grid[x, y].ToString() + " ";
                }
            }
        }
    }
}
