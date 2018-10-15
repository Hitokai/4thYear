using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
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
using static saper.SaperAlg;
using FontStyle = System.Windows.FontStyle;
using Image = System.Windows.Controls.Image;

namespace saper
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

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (minSizeRadio.IsChecked == true)
            {
                label.Content = "";
                CreateGrid(10);
                minesCoords = MinesCoord(10);
                GenerateGrid(10);
                for (int i = 0; i < minesCoords.Length; i++)
                {
                    label.Content += minesCoords[i][0].ToString() + "." + minesCoords[i][1].ToString() + "\n";
                }
            }
            else if (midSizeRadio.IsChecked == true)
            {
                CreateGrid(14);
                minesCoords = MinesCoord(14);
                GenerateGrid(14);
            }
            else if (maxSizeRadio.IsChecked == true)
            {
                CreateGrid(18);
                minesCoords = MinesCoord(18);
                GenerateGrid(18);
            }
        }

        private void CreateGrid(int size)
        {
            buttonMatrix = new Button[size, size];
            gameGrid.RowDefinitions.Clear();
            gameGrid.ColumnDefinitions.Clear();
            gameGrid.Children.Clear();
            for (int i = 0; i < size; i++)
            {
                var converter = new GridLengthConverter();
                RowDefinition row = new RowDefinition();
                row.Name = "row" + i.ToString();
                row.Height = new GridLength(1.0, GridUnitType.Star);
                row.Height = (GridLength)converter.ConvertFromString("*");

                ColumnDefinition col = new ColumnDefinition();
                col.Name = "col" + i.ToString();
                col.Width = new GridLength(1.0, GridUnitType.Star);
                col.Width = (GridLength)converter.ConvertFromString("*");

                gameGrid.RowDefinitions.Add(row);
                gameGrid.ColumnDefinitions.Add(col);
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Button button = new Button();
                    button.Click += BombFindButton_Click;
                    button.Name = "btn_" + (i + 1).ToString() + "_" + (j + 1).ToString();
                    button.Background = new SolidColorBrush(Colors.Gray);
                    button.FontSize = 13;
                    button.Foreground = new SolidColorBrush(Colors.Black);
                    button.FontWeight = FontWeights.Bold;

                    gameGrid.Children.Add(button);
                    Grid.SetRow(button, i);
                    Grid.SetColumn(button, j);

                    buttonMatrix[i, j] = button;
                }
            }
        }

        private void BombFindButton_Click(object sender, RoutedEventArgs e)
        {
            string data = (string)((Button)e.OriginalSource).Name;
            string[] nums = data.Split('_');
            ShowButtons(Convert.ToInt32(nums[1]), Convert.ToInt32(nums[2]), gameGrid.RowDefinitions.Count);
        }

        private void ShowButtons(int row, int col, int size)
        {
            if (gridNums[row, col] == 0)
            {
                buttonMatrix[row - 1, col - 1].Content = "";
                //listBut[row, col].Click -= butClick;
                buttonMatrix[row - 1, col - 1].IsEnabled = false;//отключить пустую кнопку
                buttonMatrix[row - 1, col - 1].Background = new SolidColorBrush(Colors.White);

                // открыть примыкающие клетки
                // слева, справа, сверху, снизу
                ShowButtons(row, col - 1, size-1);
                ShowButtons(row - 1, col, size-1);
                ShowButtons(row, col + 1, size-1);
                ShowButtons(row + 1, col, size-1);
            }
            else if (gridNums[row, col] != 0 && gridNums[row, col] != -1)
            {
                buttonMatrix[row - 1, col - 1].Content = gridNums[row, col];
                buttonMatrix[row - 1, col - 1].IsEnabled = false;
                buttonMatrix[row - 1, col - 1].Background = new SolidColorBrush(Colors.White);

                if (gridNums[row, col] == 1)
                    buttonMatrix[row - 1, col - 1].Foreground = new SolidColorBrush(Colors.Blue);
                else if (gridNums[row, col] == 2)
                    buttonMatrix[row - 1, col - 1].Foreground = new SolidColorBrush(Colors.Green);
                else if (gridNums[row, col] == 3)
                    buttonMatrix[row - 1, col - 1].Foreground = new SolidColorBrush(Colors.Orange);
                else
                    buttonMatrix[row - 1, col - 1].Foreground = new SolidColorBrush(Colors.Red);

                for (int i = 0; i <= size; i++)
                {
                    if (minesCoords[i][0] == Convert.ToInt32(row) && minesCoords[i][1] == Convert.ToInt32(col))
                    {
                        ShowBombs(size);
                        MessageBox.Show("Игра окончена. Вы проиграли.");
                        CreateGrid(size);
                        break;
                    }
                }
            }

            
        }

        private void ShowBombs(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    if (gridNums[i, j] == 99)
                    {
                        BitmapImage bomb = new BitmapImage();
                        bomb.BeginInit();
                        bomb.UriSource = new Uri("/Resources/bomb.png", UriKind.RelativeOrAbsolute);
                        bomb.EndInit();
                        buttonMatrix[i - 1, j - 1].Content = new Image() { Source = bomb };
                    }
                }
            }
        }
    }
}
