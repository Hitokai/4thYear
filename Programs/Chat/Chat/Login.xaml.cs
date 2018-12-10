using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static string fname;//Имя из бд
        public static string lname;//фамилия из бд
        public static string loginStat = "";//Статус логина при проверке


        public Login()
        {
            InitializeComponent();

            //Проверка на подключение к базе
            try
            {
                dataBase.connect.Open();

            }
            catch
            {
                MessageBox.Show("Connection False");
            }
            dataBase.connect.Close();

        }

        /// <summary>
        /// Клик по кнопке Login
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void login_but_Click(object sender, RoutedEventArgs e)
        {
            EnterProgram();
        }

       
        /// <summary>
        /// Функция входа в программу
        /// </summary>
        public void EnterProgram()
        {
            string selectUser = ""; //Строка запроса поиска юзера
            string passStat = "";//Статус пароля

            //Не сработает при незаполненном поле
            if (login_tb.Text != null && password_tb.Password != null)
            {
                dataBase.connect.Open();
                //Поиск пользователя
                selectUser = "select login, password, fname, lname from users where login = '" + login_tb.Text + "' and password = '" + password_tb.Password + "'";

                dataBase.command = new MySqlCommand("loginProc", dataBase.connect);//Выполнение запроса
                dataBase.command.CommandType = System.Data.CommandType.StoredProcedure;

                // Параметры запроса
                // Логин
                MySqlParameter par = new MySqlParameter();
                par.ParameterName = "inlogin";
                par.DbType = System.Data.DbType.String;
                par.MySqlDbType = MySqlDbType.VarChar;
                par.Size = 20;
                par.IsNullable = false;
                par.Value = login_tb.Text;
                dataBase.command.Parameters.Add(par);

                // Пароль
                par = new MySqlParameter();
                par.ParameterName = "inpassword";
                par.DbType = System.Data.DbType.String;
                par.MySqlDbType = MySqlDbType.VarChar;
                par.Size = 16;
                par.IsNullable = false;
                par.Value = password_tb.Password;
                dataBase.command.Parameters.Add(par);

                dataBase.reader = dataBase.command.ExecuteReader();//Ридер для чтения столбцов
                //Получение данных пользователя
                while (dataBase.reader.Read())
                {
                    loginStat = dataBase.reader[0].ToString();
                    passStat = dataBase.reader[1].ToString();
                    fname = dataBase.reader[2].ToString();
                    lname = dataBase.reader[3].ToString();
                }
                dataBase.connect.Close();
                //При нахождении пользователя Откроет основную программу
                if (loginStat != "" && passStat != "")
                {
                    try
                    {
                        dataBase.connect.Open();
                        string queryInsert = String.Format("insert into user_sessions(login) values('{0}')", loginStat);
                        dataBase.command = new MySqlCommand(queryInsert, dataBase.connect);//Выполнение запроса
                        dataBase.command.ExecuteNonQuery();
                        dataBase.connect.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Пользователь уже в сети");
                        dataBase.connect.Close();
                        return;
                    }
                    this.Hide();
                    Client client = new Client();
                    client.Show();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует");
                    dataBase.connect.Close();
                    return;
                }
            }

            else
            {
                return;
            }
        }

        /// <summary>
        /// Клик по кнопки регистрации
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Событие</param>
        private void registerWInOpen(object sender, RoutedEventArgs e)
        {
            //Скрывает окно логина и отображает окно регистрации
            this.Hide();
            Registr reg = new Registr();
            reg.Show();

        }

        /// <summary>
        /// Закрытие окна на крестик
        /// </summary>
        /// <param name="sender">Обхект</param>
        /// <param name="e">Событие</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Environment.Exit(0);
        }

        /// <summary>
        /// Вход в программу по нажатию Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EnterProgram();
            }
        }
    }
}
