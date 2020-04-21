using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DppInventory
{
    class Connection
    {
        public static MySqlConnection connection()
        {
            string server = "localhost";
            string db = "dppMotors";
            string user = "root";
            string password = "Charlie 2000";

            string stringConnection = "Database=" + db + "; Data Source=" + 
                server + "; User Id=" + user + "; Password=" + password + "";

            try
            {
                MySqlConnection connectionDB = new MySqlConnection(stringConnection);

                return connectionDB;
            }catch(MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;                
            }

        }

    }
}
