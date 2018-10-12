using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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

namespace saper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Button[,] buttonMatrix = new Button[18, 18];
        int[][] minesCoords = new int[0][];

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (minSizeRadio.IsChecked == true)
            {
                CreateGrid(10);
                minesCoords = MinesCoord(10);
                ShowBombs(minesCoords);
            }
            else if (midSizeRadio.IsChecked == true)
            {
                CreateGrid(14);
                minesCoords = MinesCoord(14);
                ShowBombs(minesCoords);
            }
            else if (maxSizeRadio.IsChecked == true)
            {
                CreateGrid(18);
                minesCoords = MinesCoord(18);
                ShowBombs(minesCoords);
            }
            MakeDigits();
        }

        private void CreateGrid(int size)
        {
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
                    button.Name = "btn_" + i.ToString() + "_" + j.ToString();
                    button.Background = new SolidColorBrush(Colors.Gray);
                    button.FontSize = 12;
                    button.Foreground = new SolidColorBrush(Colors.Black);

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
            for (int i = 0; i < minesCoords.Length; i++)
            {
                if (minesCoords[i][0] == Convert.ToInt32(nums[1]) && minesCoords[i][1] == Convert.ToInt32(nums[2]))
                    MessageBox.Show("Игра окончена. Вы проиграли.");
            }

        }

        private void ShowBombs(int[][] coords)
        {
            for (int i = 0; i < coords.Length; i++)
            {
                BitmapImage bomb = new BitmapImage();
                bomb.BeginInit();
                bomb.UriSource = new Uri("/Resources/bomb.png", UriKind.RelativeOrAbsolute);
                bomb.EndInit();
                buttonMatrix[coords[i][0], coords[i][1]].Content = new Image() { Source = bomb };
            }
        }
        
        private void MakeDigits()
        {
            int K = 0;
            for (int i = 1; i < 17; i++)
            {
                for (int j = 1; j < 17; j++)
                {
                    if (buttonMatrix[i, j].Content is null)
                    {
                        
                        if (!(buttonMatrix[i - 1, j - 1].Content is null)) K++;
                        if (!(buttonMatrix[i - 1, j].Content is null)) K++;
                        if (!(buttonMatrix[i - 1, j + 1].Content is null)) K++;
                        if (!(buttonMatrix[i, j - 1].Content is null)) K++;
                        if (!(buttonMatrix[i, j + 1].Content is null)) K++;
                        if (!(buttonMatrix[i + 1, j - 1].Content is null)) K++;
                        if (!(buttonMatrix[i + 1, j].Content is null)) K++;
                        if (!(buttonMatrix[i + 1, j + 1].Content is null)) K++;

                        buttonMatrix[i, j].Content = K;
                        K = 0;
                    }
                }
            }
        }
    }
}
