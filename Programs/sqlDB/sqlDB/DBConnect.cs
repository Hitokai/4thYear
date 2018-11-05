using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace sqlDB
{
    class DBConnect
    {
        static string connStr = "server=rooddie.ddns.net;user=root;database=cdb;password=basavka303;";

        public static void RegFunc(string newLogin, string newPassword, string newEmail, string newFname, string newLname)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            string query = String.Format("INSERT INTO users(login, password, email, fname, lname) VALUES('{0}', SHA('{1}'), '{2}', '{3}', '{4}')",
                newLogin, newPassword, newEmail, newFname, newLname);

            MySqlCommand command = new MySqlCommand(query, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }

        public static void LoginFunc(string newLogin, string newPassword)
        {
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            // запрос
            string query = String.Format("SELECT * FROM users WHERE '{0}' in (SELECT login FROM users) AND SHA('{1}') in (SELECT password FROM users)",
                newLogin, newPassword);
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            if (reader.Read())
                MessageBox.Show("ВЫ ВОШЛИ");
            else
                MessageBox.Show("ВЫЙДИ В ОКНО");

            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
    }
}
