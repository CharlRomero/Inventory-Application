using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DppInventory
{
    class ProvederController
    {   

        public List<Proveder> query(string data)
        {
            MySqlDataReader reader;
            List<Proveder> list = new List<Proveder>();
            string sql;

            if (data == null)
            {
                sql = "SELECT name_pr, telf_number_pr, email_pr FROM proveder ORDER BY name_pr ASC";
            }else
            {
                sql = "SELECT name_pr, telf_number_pr, email_pr FROM proveder WHERE name_pr LIKE '%" + data + "%' OR " +
                    "telf_numer LIKE '%" + data + "%' ORDER BY name_pr ASC";
            }

            try
            {
                MySqlConnection connectionDB = Connection.connection();
                connectionDB.Open();

                MySqlCommand command = new MySqlCommand(sql, connectionDB);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Proveder _proveder = new Proveder();

                    _proveder.Name = reader.GetString(0);                    
                    _proveder.TelfNumber = reader.GetString(1);
                    _proveder.Email = reader.GetString(2);

                    list.Add(_proveder);
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return list;
        }
        

    }
}
