using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DppInventory
{
    class Connection
    {
        public MySqlConnection connection()
        {
            string server = "localhost";
            string db = "dppMotors";
            string user = "root";
            string password = "";

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
