using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using MaterialDesignThemes.Wpf;
using static planner.XmlAddRead;

namespace planner
{
    /// <summary>
    /// 
    /// </summary>
    public partial class cardsGrid : UserControl
    {
        static Card[,] CardsMatrix; // Переменная хранящая карточки с записями
        static Grid newGrid = new Grid(); // Новый Grid для хранения карточек
        static XmlAddRead newXml = new XmlAddRead(); // Экземпляр класса XmlAddRead

        public cardsGrid()
        {
            InitializeComponent();

            // Очищаем существующий Grid
            CardsGrid.Children.Clear();
            CardsGrid.RowDefinitions.Clear();
            CardsGrid.ColumnDefinitions.Clear();

            newGrid.Margin = new Thickness(5, 5, 5, 5);

            // Добавление разделителей (всего по 4 карточки может находиться в строке)
            for (int i = 0; i < 4; i++)
            {
                var converter = new GridLengthConverter();
                ColumnDefinition col = new ColumnDefinition();
                col.Name = "col" + i.ToString();
                col.Width = new GridLength(1.0, GridUnitType.Star);
                col.Width = (GridLength)converter.ConvertFromString("250");
                newGrid.ColumnDefinitions.Add(col);
            }

            newXml.ReadCards();

            LoadCards(newXml.CardsCount);
            scroll.Content = newGrid;
        }

        // Функция загрузки записей, помещение их в карточки, а затем на Grid
        public static void LoadCards(int cardCount)
        {
            newGrid.Children.Clear();

            int cardsInRow = 0;
            int cardsInCol = 0;

            if (cardCount % 4 == 0)
            {
                cardsInRow = 4;
                cardsInCol = cardCount / 4;
            }
            else if (cardCount < 4)
            {
                cardsInRow = cardCount;
                cardsInCol = 1;
            }
            else
            {
                cardsInRow = 4;
                cardsInCol = cardCount / 4 + 1;
            }

            CardsMatrix = new Card[cardsInRow, cardsInCol]; // Задаём матрице размер

            // Создание нужного кол-ва строк
            for (int i = 0; i < cardsInCol; i++)
            {
                var converter = new GridLengthConverter();
                RowDefinition row = new RowDefinition();
                row.Name = "row" + i.ToString();
                row.Height = new GridLength(1.0, GridUnitType.Star);
                row.Height = (GridLength)converter.ConvertFromString("260");
                newGrid.RowDefinitions.Add(row);
            }

            // Создание карточек и заполнение ими Grid`а
            for (int i = 0; i < cardsInRow; i++)
            {
                for (int j = 0; j < cardsInCol; j++)
                {
                    Card miniCard = new Card();

                    miniCard.Width = 245;
                    miniCard.Height = 255;
                    miniCard.Background = new SolidColorBrush(Colors.White);

                    Grid.SetRow(miniCard, j);
                    Grid.SetColumn(miniCard, i);

                    newGrid.Children.Add(miniCard);
                    CardsMatrix[i, j] = miniCard;

                }
            }

            int x = 0;
            int y = 0;

            // Добавление контента в карточки
            for (int i = 0; i < cardCount; i++)
            {
                
                Grid miniGrid = new Grid(); // Внутренний грид карточки
                CreateRowDef(miniGrid, "0");
                CreateRowDef(miniGrid, "*");
                CreateRowDef(miniGrid, "35");

                StackPanel miniPanel1 = new StackPanel(); // Панель для группировки элементов (заголовок, контент)
                miniPanel1.Margin = new Thickness(8, 5, 8, 0);
                AddTextToHeaderAndLabel(miniPanel1, labels[i], 0);
                AddTextToHeaderAndLabel(miniPanel1, contents[i], 1);
                miniGrid.Children.Add(miniPanel1);

                StackPanel miniPanel2 = new StackPanel(); // Панель для группировки элементов(время, кнопка удаления)
                miniPanel2.Margin = new Thickness(8, 5, 8, 5);
                miniPanel2.Orientation = Orientation.Horizontal;
                Grid gridInMiniPanel2 = new Grid();
                CreateColDef(gridInMiniPanel2, "240");

                AddTextToTime(miniPanel2, dates[i]);
                gridInMiniPanel2.Children.Add(miniPanel2);
                Grid.SetColumn(miniPanel2, 0);
                miniGrid.Children.Add(gridInMiniPanel2);

                Button buttonDelete = new Button(); // Кнопка для удаления записи
                PackIcon _icon = new PackIcon { Kind = PackIconKind.Close }; // Иконка для кнопки
                buttonDelete.Width = 25;
                buttonDelete.Height = 25;
                buttonDelete.Foreground = new SolidColorBrush(Colors.Black);
                buttonDelete.Background = new SolidColorBrush(Colors.White);
                buttonDelete.BorderBrush = new SolidColorBrush(Colors.White);
                buttonDelete.Padding = new Thickness(0);
                buttonDelete.Content = _icon;
                buttonDelete.HorizontalAlignment = HorizontalAlignment.Right;
                buttonDelete.Margin = new Thickness(120, -10, 0, 0);
                buttonDelete.Click += DeleteCard;
                buttonDelete.Name = "id_" + newXml.ids[i];
                gridInMiniPanel2.Children.Add(buttonDelete);
                Grid.SetColumn(buttonDelete, 1);

                Grid.SetRow(miniPanel1, 1);
                Grid.SetRow(gridInMiniPanel2, 2);
                

                if (i % 4 == 0 && i != 0)
                {
                    y = 0;
                    x++;
                }
                CardsMatrix[y, x].Content = miniGrid;
                CardsMatrix[y, x].Name = "id_" + newXml.ids[i];
                y++;
            }

            // Удаление пустых карточек
            for (int i = 0; i < cardsInRow; i++)
            {
                for (int j = 0; j < cardsInCol; j++)
                {
                    if (CardsMatrix[i, j].Content == null)
                        newGrid.Children.Remove(CardsMatrix[i, j]);
                }
            }
        }

        // Функция для удаления записей
        private static void DeleteCard(object sender, RoutedEventArgs e)
        {
            string cardId = (sender as Button).Name.Split('_')[1];
            newXml.DeleteCard(cardId);
            newGrid.Children.Clear();
            newXml.ReadCards();
            LoadCards(newXml.CardsCount);
        }

        // Добавление заголовка и основного текста в карточку
        public static void AddTextToHeaderAndLabel(StackPanel grid, string len, int num)
        {
            ScrollViewer innerScrollViewer = new ScrollViewer();
            TextBlock innerTextBlock = new TextBlock();
            innerTextBlock.Text = len;
            innerTextBlock.TextWrapping = TextWrapping.Wrap;
            innerTextBlock.Foreground = new SolidColorBrush(Colors.Black);
            if (num == 0)
            {
                innerTextBlock.FontWeight = FontWeights.Bold;
                innerTextBlock.TextDecorations = TextDecorations.Underline;
                innerTextBlock.Margin = new Thickness(0, 0, 0, 5);
                innerTextBlock.TextAlignment = TextAlignment.Center;
                innerTextBlock.FontSize = 16;
                grid.Children.Add(innerTextBlock);
            }
            else
            {
                innerTextBlock.MinHeight = 180;

                innerScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                innerScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                innerScrollViewer.CanContentScroll = true;
                innerScrollViewer.MaxHeight = 180;

                innerScrollViewer.Content = innerTextBlock;

                grid.Children.Add(innerScrollViewer);

                Border blackBorder = new Border();
                blackBorder.BorderBrush = new SolidColorBrush(Colors.Black);
                blackBorder.BorderThickness = new Thickness(0, 1, 1, 1);
                blackBorder.VerticalAlignment = VerticalAlignment.Bottom;

                grid.Children.Add(blackBorder);
            }
        }

        // Добавление времени в карточку
        public static void AddTextToTime(StackPanel grid, string date)
        {
            TextBlock innerTextBlock = new TextBlock();
            innerTextBlock.Text = date;
            innerTextBlock.Margin = new Thickness(0, 0, 0, 0);
            innerTextBlock.Foreground = new SolidColorBrush(Colors.Black);
            //innerTextBlock.MaxWidth = 150;
            //Grid.SetColumn(innerTextBlock, 0);
            grid.Children.Add(innerTextBlock);
        }

        // Добавление разделителей в строку
        public static void CreateRowDef(Grid grid, string len)
        {
            var miniConverter = new GridLengthConverter();
            RowDefinition miniRow = new RowDefinition();
            miniRow.Height = new GridLength(1.0, GridUnitType.Star);
            miniRow.Height = (GridLength)miniConverter.ConvertFromString(len);
            grid.RowDefinitions.Add(miniRow);
        }

        // Добавление разделителей в столбец
        public static void CreateColDef(Grid grid, string len)
        {
            var miniConverter = new GridLengthConverter();
            ColumnDefinition miniCol = new ColumnDefinition();
            miniCol.Width = new GridLength(1.0, GridUnitType.Star);
            miniCol.Width = (GridLength)miniConverter.ConvertFromString(len);
            grid.ColumnDefinitions.Add(miniCol);
        }
    }

}
