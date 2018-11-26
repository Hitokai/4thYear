using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace serverChat
{
    class Program
    {
        private const string SERVERHOST = "localhost";
        private const int SERVERPORT = 100;
        private static Thread serverThread;

        static void Main(string[] args)
        {
            // Создаём и запускаем фоновый поток
            serverThread = new Thread(StartServer);
            serverThread.IsBackground = true;
            serverThread.Start();
            while (true)
                HandlerCommands(Console.ReadLine());
        }

        /// <summary>
        /// Функция получения списка пользователей
        /// </summary>
        /// <param name="cmd"></param>
        private static void HandlerCommands(string cmd)
        {
            cmd = cmd.ToLower();
            if (cmd.Contains("/getusers"))
            {
                int countUsers = Server.Clients.Count;
                for (int i = 0; i < countUsers; i++)
                {
                    Console.WriteLine("[{0}]: {1}",i,Server.Clients[i].UserName);
                }
            }
        }

        /// <summary>
        /// Функия запуска сервера
        /// </summary>
        private static void StartServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(SERVERHOST);

            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, SERVERPORT);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(new IPEndPoint(IPAddress.Any, SERVERPORT));

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)(sender);

            socket.Listen(1000);
            Console.WriteLine("Сервер запущен на IP: {0}.", ipEndPoint);
            while (true)
            {
                try
                {
                    // Подключение пользователя
                    Socket user = socket.Accept();
                    Server.NewClient(user);
                }
                catch (Exception exp) { Console.WriteLine("Ошибка: {0}",exp.Message); }
            }

        }
    }
}
