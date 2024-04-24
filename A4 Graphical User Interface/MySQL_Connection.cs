using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace A4_Graphical_User_Interface
{
    public class MySQL_Connection
    {
        // Connection string for your MySQL database
        private static string connectionString = @"server=localhost; userid=root; password=aly1132; database=AnimalAdoptionManagement";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static void HandleException(MySqlException ex)
        {
            // Handle MySQL exceptions
            Console.WriteLine("MySQL Error: " + ex.Message);
            Console.WriteLine("MySQL Error Code: " + ex.ErrorCode);
            Console.WriteLine("MySQL SQL State: " + ex.SqlState);
            // You may want to display a user-friendly message or log the error
        }
    }
}
