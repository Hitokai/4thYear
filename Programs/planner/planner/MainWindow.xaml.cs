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
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        PopupNotifier newNotifier = new PopupNotifier();
        winForms.NotifyIcon notify = new winForms.NotifyIcon();

        public MainWindow()
        {
            InitializeComponent();

            UserControl usc = null;
            usc = new cardsGrid();
            GridMain.Children.Add(usc);

            notify.Icon = SystemIcons.Application;
            notify.Visible = true;
            notify.BalloonTipText = "Окно было свёрнуто";
            notify.DoubleClick +=
                delegate(object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };

            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Tick += new EventHandler(Notifications);
            dispatcher.Interval = new TimeSpan(0, 0, 1);
            dispatcher.Start();
        }
        
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                default:
                    break;
            }
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }

        private void MinimizeWindow_OnClickButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
            this.Hide();
            notify.ShowBalloonTip(1000);
        }


        private void Notifications(object sender, EventArgs  e)
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
