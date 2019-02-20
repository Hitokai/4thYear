using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
using Image = System.Windows.Controls.Image;

namespace saper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int setFlagsCount; // Счётчик поставленных флагов
        int openButtonsCount; // Счётчик открытых клеток
        int sec, min, hours; // Переменные для хранения секунд, минут, часов

        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(TickTimer);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        /// <summary>
        /// Начало игры при нажати на кнопку Старт
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ClickOnStartBtn(object sender, RoutedEventArgs e)
        {
            if (minSizeRadio.IsChecked == true)
            {
                CreateGrid(10);
                MinesCoords = GenerateMinesCoord(10);
                GenerateGrid(10);
            }
            else if (midSizeRadio.IsChecked == true)
            {
                CreateGrid(14);
                MinesCoords = GenerateMinesCoord(14);
                GenerateGrid(14);
            }
            else if (maxSizeRadio.IsChecked == true)
            {
                CreateGrid(18);
                MinesCoords = GenerateMinesCoord(18);
                GenerateGrid(18);
            }
            bombsLabel.Content = "Бомбы: " + MinesCoords.Length;
        }

        /// <summary>
        /// Генерация поля для игры в зависимости от выбранного размера
        /// </summary>
        /// <param name="size">размер поля</param>
        private void CreateGrid(int size)
        {
            sec = 0;
            min = 0;
            hours = 0;
            timer.Start();

            setFlagsCount = 0;

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
                    button.Click += FindBombBtnClick;
                    button.MouseRightButtonDown += AddFlagButton;
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

        /// <summary>
        /// Действия происходящие при нажатии на кнопку на поле игры
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событиие</param>
        private void FindBombBtnClick(object sender, RoutedEventArgs e)
        {
            string data = (string)((Button)e.OriginalSource).Name;
            string[] nums = data.Split('_');
            ShowButtons(Convert.ToInt32(nums[1]), Convert.ToInt32(nums[2]), gameGrid.RowDefinitions.Count);

            openButtonsCount = 0;
            for (int i = 0; i < gameGrid.RowDefinitions.Count; i++)
            {
                for (int j = 0; j < gameGrid.ColumnDefinitions.Count; j++)
                {
                    if (buttonMatrix[i, j].IsEnabled == false)
                        openButtonsCount++;
                }
            }

            if (openButtonsCount + MinesCoords.Length == gameGrid.RowDefinitions.Count * gameGrid.RowDefinitions.Count)
            {
                timer.Stop();
                MessageBox.Show("Вы победили");
                CreateGrid(gameGrid.RowDefinitions.Count);
                MinesCoords = GenerateMinesCoord(gameGrid.RowDefinitions.Count);
                GenerateGrid(gameGrid.RowDefinitions.Count);
            }    
        }

        /// <summary>
        /// Добавление флагов при нажатии на правую кнопку мыши
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void AddFlagButton(object sender, MouseEventArgs e)
        {
            Button currBtn = (sender as Button);
            
            int row = 1 + Grid.GetRow(currBtn),
                col = 1 + Grid.GetColumn(currBtn);
            
            if (gridNums[row, col] == 99)
                openButtonsCount++;

            if (currBtn.Content == null)
            {
                currBtn.Content = "◄";
                currBtn.Foreground = new SolidColorBrush(Colors.Red);
                setFlagsCount++;
            }
            else if (currBtn.Content == "◄")
            {
                currBtn.Content = "?";
                currBtn.Foreground = new SolidColorBrush(Colors.Black);
                setFlagsCount--;
                if (gridNums[row, col] == 99)
                    openButtonsCount--;
            }
            else
            {
                currBtn.Content = null;
                currBtn.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        /// <summary>
        /// Функция показывающая кнопки при нажатии на них
        /// </summary>
        /// <param name="row">строки</param>
        /// <param name="col">столбцы</param>
        /// <param name="size">размер</param>
        private void ShowButtons(int row, int col, int size)
        {
            
            if (gridNums[row, col] == 0)
            {
                gridNums[row, col] = 100;
                buttonMatrix[row - 1, col - 1].Content = "";
                buttonMatrix[row - 1, col - 1].IsEnabled = false;
                buttonMatrix[row - 1, col - 1].Background = new SolidColorBrush(Colors.White);
                // открыть примыкающие клетки
                // слева, сверху, справа, снизу
                ShowButtons(row, col - 1, size);
                ShowButtons(row - 1, col, size);
                ShowButtons(row, col + 1, size);
                ShowButtons(row + 1, col, size);

                // Открывает клетки по диагонали
                ShowButtons(row + 1, col - 1, size);
                ShowButtons(row + 1, col + 1, size);
                ShowButtons(row - 1, col + 1, size);
                ShowButtons(row - 1, col - 1, size);
            }
            else if (gridNums[row, col] < 100 && gridNums[row, col] != -1)
            {
                if (buttonMatrix[row - 1, col - 1].Content == "◄")
                {
                    setFlagsCount -= 1;
                    if (setFlagsCount < 0)
                        setFlagsCount = 0;
                }

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

                for (int i = 0; i < MinesCoords.Length; i++)
                {
                    if (MinesCoords[i][0] == Convert.ToInt32(row) && MinesCoords[i][1] == Convert.ToInt32(col))
                    {
                        ShowBombs(size);
                        timer.Stop();
                        MessageBox.Show("Игра окончена. Вы проиграли.");
                        CreateGrid(size);
                        MinesCoords = GenerateMinesCoord(size);
                        GenerateGrid(size);
                        break;
                    }
                }
            }
            bombsLabel.Content = "Бомбы: " + MinesCoords.Length;

        }

        /// <summary>
        /// Функция для показа всех бомб находищихся на поле
        /// </summary>
        /// <param name="size">размер</param>
        private void ShowBombs(int size)
        {
            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    if (gridNums[i, j] == 99)
                    {
                        buttonMatrix[i - 1, j - 1].Background = new SolidColorBrush(Colors.Red);
                        BitmapImage bomb = new BitmapImage();
                        bomb.BeginInit();
                        bomb.UriSource = new Uri("/Resources/bomb.png", UriKind.RelativeOrAbsolute);
                        bomb.EndInit();
                        buttonMatrix[i - 1, j - 1].Content = new Image() { Source = bomb };
                    }
                }
            }
        }

        /// <summary>
        /// Таймер
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void TickTimer(object sender, EventArgs e)
        {
            sec++;
            if (sec == 60)
            { sec = 0; min++; }
            else if (min == 60) { min = 0; hours++; }
            timeLabel.Content = "Время: " + hours.ToString() + ":" + min.ToString() + ":" + sec.ToString();
        }
    }
}
