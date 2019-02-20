using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using winForms = System.Windows.Forms;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using Tulpep.NotificationWindow;
using static planner.XmlAddRead;

namespace planner
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {

        PopupNotifier newNotifier = new PopupNotifier(); // Экземпляр объекта оповещений
        winForms.NotifyIcon notify = new winForms.NotifyIcon();

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Создание экземпляра объекта UserControl для смены содержимого Grid
            UserControl usc = null;
            usc = new cardsGrid();
            GridMain.Children.Add(usc);

            // Оповещение при сворачивании окна в трей
            notify.Icon = SystemIcons.Application;
            notify.Visible = false;
            notify.BalloonTipText = "Окно было свёрнуто";
            notify.DoubleClick +=
                delegate(object sender, EventArgs args)
                {
                    notify.Visible = false;
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };

            // Таймер проверяющий соответствие времени системы и событий в планировщике
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Tick += new EventHandler(ShowNotifications);
            dispatcher.Interval = new TimeSpan(0, 0, 1);
            dispatcher.Start();
        }

        /// <summary>
        /// Метод нажатия на кнопку открытия бокового меню
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">событие</param>
        private void ClickOnMenuBtn(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Метод нажатия на кнопку закрытия бокового меню
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ClickOnCloseBtn(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Метод для изменения содержимого Grid при выборе пунктов меню
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событиеи</param>
        private void ChangeListViewMenu(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    usc = new cardsGrid();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemCreate":
                    usc = new createCard();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemSettings":
                    usc = new settings();
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ClickClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Возможность перетаскивания окна по экрану
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        /// <summary>
        /// Сворачивание окна в трей
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void MinimizeMenu(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            notify.Visible = true;
            newNotifier.TitleText = "Planner";
            newNotifier.ContentText = "Приложение свёрнуто в трей";
            newNotifier.Popup();
            this.Hide();
        }

        /// <summary>
        /// Оповещение о событии
        /// </summary>
        /// <param name="sender">объект</param>
        /// <param name="e">событие</param>
        private void ShowNotifications(object sender, EventArgs  e)
        {
            string currTime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            if (dates.Contains(currTime))
            {
                string notifText = contents[dates.IndexOf(currTime)];
                string notifHead = labels[dates.IndexOf(currTime)];
                newNotifier.TitleText = notifHead;
                newNotifier.ContentText = notifText;
                newNotifier.Popup();
            }
        }

    }

}
