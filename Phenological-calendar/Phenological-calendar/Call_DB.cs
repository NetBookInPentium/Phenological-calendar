using System.Configuration;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace Phenologicalcalendar
{
    public class Call_DB
    {
        string connStr = "server=localhost;user=root;database=testdb;password=277353;";
        MySqlConnection connection;

        public Call_DB()
        {
            connection = new MySqlConnection(connStr);
            
        }

        public MySqlDataReader Request(string query)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Выполнил: " + query);
            Console.ForegroundColor = ConsoleColor.White;

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public string Test(string query) 
        {
            string str = "";
            MySqlDataReader reader = Request(query);
            while (reader.Read())
            {
                str = reader.GetString(0);
            }
            connection.Close();
            return str;
        }

        public List<string> Test_list(string query) 
        { 
            List<string> list = new List<string>();
            MySqlDataReader reader = Request(query);
            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }
            connection.Close();
            return list;
        }
    }
}
