using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        private Socket serverSocket;
        private Thread clientThread;
        private const string SERVERHOST = "127.0.0.1";
        private const int SERVERPORT = 100;

        public Client()
        {
            InitializeComponent();

            // Создаём подключение и запускаем поток
            Connect();
            clientThread = new Thread(Listener);
            clientThread.IsBackground = true;
            clientThread.Start();

            string Name = DBConnect.user;
            userChip.Content = Name;
            userChip.Icon = Name[0];
            // Отправляем серверу комманду с именем клиента
            Send("#setname&" + Name);
        }

        /// <summary>
        /// Функция для прослушивания порта и получения сообщений
        /// </summary>
        private void Listener()
        {
            while (serverSocket.Connected)
            {
                // Создаём буфер для сообщений
                byte[] buffer = new byte[8196];
                // Получение сообщения
                int bytesRec = serverSocket.Receive(buffer);
                // Декодируем сообщение
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                // Если в сообщении есть команда обновляем все сообщения
                if (data.Contains("#updatechat"))
                {
                    UpdateChat(data);
                    continue;
                }
            }
        }

        /// <summary>
        /// Функция подключения к серверу
        /// </summary>connect
        private void Connect()
        {
            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(SERVERHOST);
                IPAddress ipAddress = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, SERVERPORT);

                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint remote = (EndPoint)(sender);

                // Создание подключения
                serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(ipEndPoint);
            }
            catch { chatBox.Text = ("Сервер недоступен!"); }
        }

        /// <summary>
        /// Очистка поля сообщений
        /// </summary>
        private void ClearChat()
        {
            // Получение доступа к элементу в другом потоке
            Dispatcher.BeginInvoke(new ThreadStart(delegate {
                chatBox.Text = string.Empty;
            }));
        }

        /// <summary>
        /// Функция обновления чата (получение всех сообщений из буфера сервера
        /// </summary>
        /// <param name="data"></param>
        private void UpdateChat(string data)
        {
            ClearChat();
            string[] messages = data.Split('&')[1].Split('|');
            int countMessages = messages.Length;
            if (countMessages <= 0) return;
            for (int i = 0; i < countMessages; i++)
            {
                try
                {
                    if (string.IsNullOrEmpty(messages[i])) continue;
                    Print(String.Format("[{0}]: {1}.", messages[i].Split('~')[0], messages[i].Split('~')[1]));
                }
                catch { continue; }
            }
        }

        /// <summary>
        /// Функция отправки сообщений
        /// </summary>
        /// <param name="data"></param>
        private void Send(string data)
        {
            try
            {
                // Создание закодированного буфера сообщения
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = serverSocket.Send(buffer);
            }
            catch { chatBox.Text = ("Связь с сервером прервалась..."); }
        }

        /// <summary>
        /// Функция для добавления сообщения в поле
        /// </summary>
        /// <param name="msg"></param>
        private void Print(string msg)
        {
            // Получение доступа к элементу в другом потоке
            Dispatcher.BeginInvoke(new ThreadStart(delegate {
                if (chatBox.Text.Length == 0)
                    chatBox.Text += msg;
                else
                {
                    chatBox.Text += (Environment.NewLine + msg);
                    scroll.ScrollToEnd();
                }   
            }));
        }

        /*/// <summary>
        /// Функция выполняющаяся при нажатии на кнопку "Подключится"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterChat_Click(object sender, EventArgs e)
        {
            string Name = userName.Text;
            if (string.IsNullOrEmpty(Name)) return;
            // Отправляем серверу комманду с именем клиента
            Send("#setname&" + Name);

            chatBox.IsEnabled = true;
            chat_msg.IsEnabled = true;
            chat_send.IsEnabled = true;
            userName.IsEnabled = false;
            connBtn.IsEnabled = false;
        }*/

        /// <summary>
        /// Функция отправки сообщений при нажатии на кнопку "Отправить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chat_send_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        /// <summary>
        /// Функция отправки сообщения
        /// </summary>
        private void SendMessage()
        {
            try
            {
                string data = chat_msg.Text;
                if (string.IsNullOrEmpty(data)) return;
                // Отправляем серверу комманду с сообщением
                Send("#newmsg&" + data);
                chat_msg.Text = string.Empty;
            }
            catch { MessageBox.Show("Ошибка при отправке сообщения!"); }
        }

        private void chatBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SendMessage();
        }

        private void chat_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SendMessage();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
