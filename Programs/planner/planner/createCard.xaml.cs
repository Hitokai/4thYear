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
    /// 
    /// </summary>
    public partial class createCard : UserControl
    {

        /// <summary>
        /// Конструктор
        /// </summary>
        public createCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавление записей
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ClickOnAddBtn(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// Обновление содержимого карточки для предпросмотра
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ChangeContentOnTb(object sender, TextChangedEventArgs e)
        {
            string objName = (string)((TextBox)e.OriginalSource).Name;
            if (objName == "contentTextBox")
            {
                if (contentTextBox.Text.Length == 0)
                    cardContent.Text = "Текст";
                else
                {
                    cardContent.Text = contentTextBox.Text;
                    counter.Text = contentTextBox.Text.Length.ToString() + "/400";
                }
            }
            else
                if (headerBox.Text.Length == 0)
                    cardHeader.Text = "Заголовок";
                else
                    cardHeader.Text = headerBox.Text;
        }

        /// <summary>
        /// Изменение даты
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ChangeDateValue(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (dateTime.Text.Length == 0)
                cardDateTime.Text = "Дата и время";
            else
                cardDateTime.Text = dateTime.Text;
        }
    }
}
