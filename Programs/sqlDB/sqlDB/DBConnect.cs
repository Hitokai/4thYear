using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace sqlDB
{
    class DBConnect
    {
        
        static string connStr = "server=rooddie.ddns.net;user=root;database=cdb;password=basavka303;";
        static MySqlConnection conn = new MySqlConnection(connStr);

        private static DataTable dataTable = new DataTable();

        public static string tableName = "home";

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

        public static void LoadToDataGrid(string table, DataGrid dataGrid)
        {
            string sql = "";

            if (table == "drivers")
            {
                sql =
                    @"SELECT fname as 'Имя', lname as 'Фамилия', mname as 'Отчество', passport_num as 'Номер паспорта', age as 'Возраст', 
                      category as 'Категория прав', model as 'Автомобиль' FROM drivers inner join rights_category on category_id = id_category
                      inner join cars on cars.car_id = drivers.car_id";
            }

            else if (table == "cars")
            {
                sql = @"SELECT cars.model as 'Модель автомобиля', cars.plate_number as 'Гос. Номер', category 'Категория прав', trailers.model as 'Модель прицепа'
                        from cars inner join rights_category on category_id = id_category
                        inner join trailer_to_car on trailer_to_car.car_id = cars.car_id
                        inner join trailers on cars.car_id = trailer_to_car.car_id";
            }

            else if (table == "trailers")
            {
                
            }

            /*string sql = String.Format(@"SELECT 
            driver_id as 'ID водителя',
            fname as 'Фамилия',
            lname as 'Имя',
            mname as 'Отчество',
            category_id as 'Номер категории',
            passport_num as 'Номер паспорта',
            date_of_birth as 'Дата рождения',
            car_id as 'ID машины' FROM {0}", table);*/

            conn.Open();

            MySqlCommand cmdSel = new MySqlCommand(sql, conn);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
            da.Fill(dt);

            da.Fill(dataTable);

            dataGrid.DataContext = dt;

            conn.Close();
        }

        public static void UpdateDataGrid(DataGrid dataGrid)
        {
            conn.Open();

            string query = String.Format("SELECT * FROM {0}", tableName);
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, conn);

            
            MySqlDataAdapter data = new MySqlDataAdapter(command);
            DataTable dt = new DataTable();
            dt = ((DataView)dataGrid.ItemsSource).ToTable();

            MySqlCommandBuilder mcb = new MySqlCommandBuilder(data);

            data.Update(dt);
            MessageBox.Show(tableName);
            conn.Close();
        }
    }
}
