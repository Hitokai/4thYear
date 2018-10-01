using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
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
        Button[,] listButtons = new Button[9, 9];
        int[,] newGrid = new int[9, 9];

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button button = new Button();
                    button.Name = "btn" + i.ToString() + j.ToString();
                    button.Click += button_Click;
                    button.MouseRightButtonUp += rightClick;
                    button.Background = new SolidColorBrush(Colors.Black) { Opacity = 0.2 };
                    button.FontSize = 26;
                    button.Foreground = new SolidColorBrush(Colors.Red);
                    button.Visibility = Visibility.Hidden;
                    gridBut.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);
                    listButtons[i, j] = button;
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string data = (string)((Button)e.OriginalSource).Content;
            if (data == "9")
                ((Button)e.OriginalSource).Content = "1";
            else
                ((Button)e.OriginalSource).Content = (Convert.ToInt32(data) + 1).ToString();
            string numb = (string)((Button)e.OriginalSource).Content;
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Substring(3, 1));
            int y = int.Parse(button.Name.Substring(4, 1));
            newGrid[x, y] = Convert.ToInt32(numb);
            finishGame();
        }

        private void rightClick(object sender, MouseButtonEventArgs e)
        {
            string data = (string)((Button)e.OriginalSource).Content;
            if (data == "1" || data == "0")
                ((Button)e.OriginalSource).Content = "9";
            else
                ((Button)e.OriginalSource).Content = (Convert.ToInt32(data) - 1).ToString();
            string numb = (string)((Button)e.OriginalSource).Content;
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Substring(3, 1));
            int y = int.Parse(button.Name.Substring(4, 1));
            newGrid[x, y] = Convert.ToInt32(numb);
            finishGame();
        }

        private void createContent(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "";
            init(grid);
            update(grid);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    listButtons[i, j].Content = "0";
                    listButtons[i, j].Visibility = Visibility.Visible;
                    listButtons[i, j].IsEnabled = true;
                    Random chance = new Random(Guid.NewGuid().GetHashCode());
                    int randomNumb = chance.Next(0, 1000);
                    if (!(i == 7 && j == 2))
                    {
                        listButtons[i, j].Content = grid[i, j].ToString();
                        listButtons[i, j].IsEnabled = false;
                        listButtons[i, j].Foreground = new SolidColorBrush(Colors.DarkRed);
                    }
                    newGrid[i, j] = grid[i, j];
                }
            }
            btnStart.IsEnabled = false;
        }

        private void finishGame()
        {
            bool res = isEqual();
            if (res)
            {
                resultLabel.Content = "Ты победил!";
                btnStart.IsEnabled = true;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        listButtons[i, j].IsEnabled = false;
                    }
                }
            }
            else
            {
                resultLabel.Content = "Идёт игра";
            }
        }

        private bool isEqual()
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (newGrid[i, j] == grid[i, j])
                        count += 1;
                }
            }

            if (count == 81)
                return true;
            else
                return false;
        }
    }
}
