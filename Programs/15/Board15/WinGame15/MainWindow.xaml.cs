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
using Board15;

namespace WinGame15
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int size = 4;
        Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
        }

        // Старт игры при нажатии на кнопку Старт
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int steps = rnd.Next(700, 1600);
            game.Start(steps);
            button_start.Content = "Перемешать";
            ShowButtons();
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            // Если игра  уже решена, то ничего не делаем
            if (game.Solved())
                return;
            Button button = (Button) sender;
            // Парсим название кнопок (они содержат координаты XY)
            int x = int.Parse(button.Name.Substring(3, 1));
            int y = int.Parse(button.Name.Substring(4, 1));
            game.Press(x, y);
            ShowButtons();  
            if (game.Solved())
            {
                button_start.Content = "Старт";
                labelMoves.Content = "Игра закончена за " + game.moves + " шаг(а)";
            }  
        }

        // Заполняем кнопки нулями и делаем их невидимыми
        void HideButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigit(0, x, y);
        }

        // Показ кнопок
        void ShowButtons()
        {
            // Проходим по всему массиву и делаем кнопки видимыми
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigit(game.GetDigit(x, y), x, y);
            labelMoves.Content = "Кол-во ходов: " + game.moves;
        }

        // Скрытие кнопок
        void ShowDigit(int digit, int x, int y)
        {
            // Находим кнопку по названию и вписываем в неё цифру
            Button button = (Button) this.FindName("btn" + x + y);
            button.Content = digit.ToString();
            // Делаем кнопку невидимой если в ней 0, и видимой если  в ней не 0
            button.Visibility = digit == 0 ? Visibility.Hidden : Visibility.Visible;
        }
    }
}
