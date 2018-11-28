using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Chat
{
    class DBConnect
    {
        
        static string connStr = "server=rooddie.ddns.net;user=root;database=chat_login;password=basavka303;";
        static MySqlConnection conn = new MySqlConnection(connStr);

        public static string user;

        public static void RegFunc(string newLogin, string newPassword, string newEmail)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = String.Format("INSERT INTO users(login, password, email) VALUES('{0}', SHA('{1}'), '{2}')",
                newLogin, newPassword, newEmail);

            MySqlCommand command = new MySqlCommand(query, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }

        public static bool LoginFunc(string newLogin, string newPassword)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // запрос
            string query = String.Format("SELECT true FROM users WHERE '{0}' in (SELECT login FROM users) AND SHA('{1}') in (SELECT password FROM users)",
                newLogin, newPassword);
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            bool res = reader.Read();
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();

            return res;
        }
    }
}
