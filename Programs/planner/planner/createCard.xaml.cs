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
using System.Xml;
using static planner.XmlAddRead;

namespace planner
{
    /// <summary>
    /// Interação lógica para UserControlCreate.xam
    /// </summary>
    public partial class createCard : UserControl
    {
        public createCard()
        {
            InitializeComponent();
        }

        private void cardAddButton_Click(object sender, RoutedEventArgs e)
        {
            string headerText = headerBox.Text;
            string contentText = contentTextBox.Text;
            string dateTimeText = dateTime.Text;

            XmlAddRead card = new XmlAddRead { Title = headerText, Content = contentText, DateTime = dateTimeText};
            card.AddCard();

            headerBox.Clear();
            contentTextBox.Clear();
            dateTime.Text = "";
            
        }

        private void contentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string objName = (string)((TextBox)e.OriginalSource).Name;
            if (objName == "contentTextBox")
            {
                cardContent.Text = contentTextBox.Text;
                counter.Text = contentTextBox.Text.Length.ToString() + "/400";
            }
            else
                cardHeader.Text = headerBox.Text;
        }

        private void dateTime_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            cardDateTime.Text = dateTime.Text;
        }
    }
}
