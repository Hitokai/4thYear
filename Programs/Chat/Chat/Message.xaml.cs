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

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : UserControl
    {
        public Message(BitmapImage image, string textMsg)
        {
            InitializeComponent();

            Photo.Fill = new ImageBrush(image);
            MsgBox.Text = textMsg;
            Height = StackMsg.Height;
            MainGrid.Height = StackMsg.Height;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(StackMsg.Height.ToString());
        }
    }
}
