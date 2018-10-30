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
using static sudoku.SudokuAlg;

namespace sudoku
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[,] listButtons = new Button[9, 9]; // массив кнопок
        int[,] newGrid = new int[9, 9]; // массив игрового поля

        public MainWindow()
        {
            InitializeComponent();
            // Создание кнопок
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button button = new Button();
                    button.Name = "btn" + i.ToString() + j.ToString();
                    button.Click += ClickOnLeftButton;
                    button.MouseRightButtonDown += ClickOnRightButton;
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

        // Обработчик нажитий левой кнопкой мыши на ячейку
        private void ClickOnLeftButton(object sender, RoutedEventArgs e)
        {
            string data = (string)((Button)e.OriginalSource).Content;
            if (data == "9" || data == null)
                ((Button)e.OriginalSource).Content = "1";
            else
                ((Button)e.OriginalSource).Content = (Convert.ToInt32(data) + 1).ToString();
            string numb = (string)((Button)e.OriginalSource).Content;
            Button button = (Button)sender;
            int x = int.Parse(button.Name.Substring(3, 1));
            int y = int.Parse(button.Name.Substring(4, 1));
            newGrid[x, y] = Convert.ToInt32(numb);
            FinishGame();
        }

        // Обработчик нажитий правой кнопкой мыши на ячейку
        private void ClickOnRightButton(object sender, MouseEventArgs e)
        {
            Button currBtn = (sender as Button);
            var data = currBtn.Content;
            if (data == null || data.ToString() == "1")
                currBtn.Content = "9";
            else
                currBtn.Content = (Convert.ToInt32(data) - 1).ToString();
            string numb = currBtn.Content.ToString();
            int x = int.Parse(currBtn.Name.Substring(3, 1));
            int y = int.Parse(currBtn.Name.Substring(4, 1));
            newGrid[x, y] = Convert.ToInt32(numb);
            FinishGame();
        }

        // Создание цифр и помещение их в кнопки
        private void CreateContent(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "";
            initGrid(grid);
            updateGrid(grid);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    listButtons[i, j].Content = null;
                    listButtons[i, j].Visibility = Visibility.Visible;
                    listButtons[i, j].IsEnabled = true;
                    Random chance = new Random(Guid.NewGuid().GetHashCode());
                    int randomNumb = chance.Next(0, 1000);
                    if (randomNumb % 1.5 == 0)
                    {
                        listButtons[i, j].Content = grid[i, j].ToString();
                        listButtons[i, j].IsEnabled = false;
                        listButtons[i, j].Foreground = new SolidColorBrush(Colors.DarkRed);
                        newGrid[i, j] = grid[i, j];
                    }
                }
            }
            btnStart.IsEnabled = false;
        }

        // Проверка поля. Если массивы равны - закончить игру.
        private void FinishGame()
        {
            bool res = IsEqual();
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

        // Сравнивание двух массивов, если сумма равна 81, то это победа
        private bool IsEqual()
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
