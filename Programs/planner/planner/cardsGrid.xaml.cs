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
    /// Interação lógica para UserControlHome.xam
    /// </summary>
    public partial class cardsGrid : UserControl
    {
        private PackIcon _icon = new PackIcon { Kind = PackIconKind.Close };
        Card[,] CardsMatrix;
        Grid newGrid = new Grid();
        XmlAddRead newXml = new XmlAddRead();

        public cardsGrid()
        {
            InitializeComponent();

            CardsGrid.Children.Clear();
            CardsGrid.RowDefinitions.Clear();
            CardsGrid.ColumnDefinitions.Clear();

            newGrid.Margin = new Thickness(5, 5, 5, 5);
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
            // обход всех узлов в корневом элементе

            LoadCards(newXml.CardsCount);
        }

        public void LoadCards(int cardCount)
        {
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

            CardsMatrix = new Card[cardsInRow, cardsInCol];

            for (int i = 0; i < cardsInCol; i++)
            {
                var converter = new GridLengthConverter();
                RowDefinition row = new RowDefinition();
                row.Name = "row" + i.ToString();
                row.Height = new GridLength(1.0, GridUnitType.Star);
                row.Height = (GridLength)converter.ConvertFromString("260");
                newGrid.RowDefinitions.Add(row);
            }

            for (int i = 0; i < cardsInRow; i++)
            {
                for (int j = 0; j < cardsInCol; j++)
                {
                    /*if (cardsInRow - (cardCount - (i + j)) == cardCount % 4)
                    {
                        break;
                    }*/

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
            scroll.Content = newGrid;

            

            int x = 0;
            int y = 0;


            for (int i = 0; i < cardCount; i++)
            {
                
                Grid miniGrid = new Grid();
                CreateRowDef(miniGrid, "0");
                CreateRowDef(miniGrid, "*");
                CreateRowDef(miniGrid, "35");

                StackPanel miniPanel1 = new StackPanel();
                miniPanel1.Margin = new Thickness(8, 5, 8, 0);
                AddTextToHeaderAndLabel(miniPanel1, newXml.labels[i], 0);
                AddTextToHeaderAndLabel(miniPanel1, newXml.contents[i], 1);
                miniGrid.Children.Add(miniPanel1);

                StackPanel miniPanel2 = new StackPanel();
                miniPanel2.Margin = new Thickness(8, 5, 8, 5);
                miniPanel2.Orientation = Orientation.Horizontal;
                Grid gridInMiniPanel2 = new Grid();
                CreateColDef(gridInMiniPanel2, "*");
                AddTextToTime(miniPanel2, newXml.dates[i]);
                miniGrid.Children.Add(miniPanel2);

                Button deleteButton = new Button();
                deleteButton.Width = 25;
                deleteButton.Height = 25;
                deleteButton.Foreground = new SolidColorBrush(Colors.Black);
                deleteButton.Background = new SolidColorBrush(Colors.White);
                deleteButton.BorderBrush = new SolidColorBrush(Colors.White);
                deleteButton.FontSize = 1;
                deleteButton.Padding = new Thickness(0);
                deleteButton.Content = _icon;
                deleteButton.HorizontalAlignment = HorizontalAlignment.Right;
                deleteButton.Margin = new Thickness(50, -10, 0, 0);
                deleteButton.Click += deleteCard;
                deleteButton.Name = "id_" + newXml.ids[i];
                Grid.SetColumn(deleteButton, 0);
                miniPanel2.Children.Add(deleteButton);

                Grid.SetRow(miniPanel1, 1);
                Grid.SetRow(miniPanel2, 2);
                

                if (i % 4 == 0 && i != 0)
                {
                    y = 0;
                    x++;
                }
                CardsMatrix[y, x].Content = miniGrid;
                CardsMatrix[y, x].Name = "id_" + newXml.ids[i];
                y++;
            }

            for (int i = 0; i < cardsInRow; i++)
            {
                for (int j = 0; j < cardsInCol; j++)
                {
                    if (CardsMatrix[i, j].Content == null)
                        newGrid.Children.Remove(CardsMatrix[i, j]);
                }
            }
        }

        private void deleteCard(object sender, RoutedEventArgs e)
        {
            string cardId = (sender as Button).Name.Split('_')[1];
            newXml.DeleteCard(cardId);
            newGrid.Children.Clear();
            newXml.ReadCards();
            LoadCards(newXml.CardsCount);
        }

        public void AddTextToHeaderAndLabel(StackPanel grid, string len, int num)
        {
            TextBlock tb = new TextBlock();
            tb.Text = len;
            tb.TextWrapping = TextWrapping.Wrap;
            if (num == 1)
                tb.Height = 164;
            else
            {
                tb.FontWeight = FontWeights.Bold;
                tb.TextDecorations = TextDecorations.Underline;
                tb.Margin = new Thickness(0, 0, 0, 5);
                tb.TextAlignment = TextAlignment.Center;
                tb.FontSize = 16;
            }
                
            tb.Foreground = new SolidColorBrush(Colors.Black);
            grid.Children.Add(tb);
        }

        public void AddTextToTime(StackPanel grid, string date)
        {
            TextBlock tb = new TextBlock();
            tb.Text = date;
            tb.Margin = new Thickness(0, 0, 0, 0);
            tb.Foreground = new SolidColorBrush(Colors.Black);
            Grid.SetColumn(tb, 0);
            grid.Children.Add(tb);
        }

        public void CreateRowDef(Grid grid, string len)
        {
            var miniConverter = new GridLengthConverter();
            RowDefinition miniRow = new RowDefinition();
            miniRow.Height = new GridLength(1.0, GridUnitType.Star);
            miniRow.Height = (GridLength)miniConverter.ConvertFromString(len);
            grid.RowDefinitions.Add(miniRow);
        }

        public void CreateColDef(Grid grid, string len)
        {
            var miniConverter = new GridLengthConverter();
            ColumnDefinition miniRow = new ColumnDefinition();
            miniRow.Width = new GridLength(1.0, GridUnitType.Star);
            miniRow.Width = (GridLength)miniConverter.ConvertFromString(len);
            grid.ColumnDefinitions.Add(miniRow);
        }
    }

}
