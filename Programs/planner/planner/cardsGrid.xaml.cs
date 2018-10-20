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
                cardsInCol = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(cardCount % 4 + 1)));
            }

            CardsMatrix = new Card[cardsInCol, cardsInRow];

            for (int i = 0; i < cardsInCol; i++)
            {
                var converter = new GridLengthConverter();
                RowDefinition row = new RowDefinition();
                row.Name = "row" + i.ToString();
                row.Height = new GridLength(1.0, GridUnitType.Star);
                row.Height = (GridLength)converter.ConvertFromString("260");
                newGrid.RowDefinitions.Add(row);
            }

            for (int i = 0; i < cardsInCol; i++)
            {
                for (int j = 0; j < cardsInRow; j++)
                {
                    Card miniCard = new Card();

                    miniCard.Width = 245;
                    miniCard.Height = 255;
                    miniCard.Background = new SolidColorBrush(Colors.White);

                    Grid.SetRow(miniCard, i);
                    Grid.SetColumn(miniCard, j);

                    newGrid.Children.Add(miniCard);
                    CardsMatrix[i, j] = miniCard;
                }
            }
            scroll.Content = newGrid;

            for (int i = 0; i < cardsInCol; i++)
            {
                for (int j = 0; j < cardsInRow; j++)
                {
                    Grid miniGrid = new Grid();
                    CreateRowDef(miniGrid, "0");
                    CreateRowDef(miniGrid, "*");
                    CreateRowDef(miniGrid, "35");

                    StackPanel miniPanel1 = new StackPanel();
                    miniPanel1.Margin = new Thickness(8, 5, 8, 0);
                    addText(miniPanel1, newXml.labels[i], 0);
                    addText(miniPanel1, newXml.contents[i], 1);
                    miniGrid.Children.Add(miniPanel1);

                    StackPanel miniPanel2 = new StackPanel();
                    miniPanel2.Margin = new Thickness(8, 5, 8, 5);
                    miniPanel2.Orientation = Orientation.Horizontal;
                    addText2(miniPanel2, newXml.dates[i]);
                    miniGrid.Children.Add(miniPanel2);

                    MaterialDesignThemes.Wpf.PopupBox box1 = new MaterialDesignThemes.Wpf.PopupBox();
                    box1.PlacementMode = PopupBoxPlacementMode.RightAndAlignMiddles;
                    box1.HorizontalAlignment = HorizontalAlignment.Right;
                    box1.Foreground = new SolidColorBrush(Colors.Black);
                    box1.Background = new SolidColorBrush(Colors.Black);
                    box1.Margin = new Thickness(132, 0, 0, -5);

                    StackPanel dropMenu = new StackPanel();
                    Button deleteButton = new Button();
                    deleteButton.Content = "Удалить";
                    dropMenu.Children.Add(deleteButton);
                    box1.Content = dropMenu;

                    miniPanel2.Children.Add(box1);

                    Grid.SetRow(miniPanel1, 1);
                    Grid.SetRow(miniPanel2, 2);

                    CardsMatrix[i, j].Content = miniGrid;
                }   
            }
        }
        public void addText(StackPanel grid, string len, int num)
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

        public void addText2(StackPanel grid, string date)
        {
            TextBlock tb = new TextBlock();
            tb.Text = date;
            tb.Margin = new Thickness(0, 0, 0, 0);
            tb.Foreground = new SolidColorBrush(Colors.Black);
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
    }

}
