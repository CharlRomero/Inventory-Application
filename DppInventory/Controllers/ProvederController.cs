using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DppInventory
{
    class ProvederController : Connection, ControllerRepository<Proveder>
    {

        public List<Object> Query(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<Object>();
            string sql;

            if (data == null)
            {
                sql = "SELECT id_pr, name_pr, telf_number_pr, email_pr FROM proveder ORDER BY name_pr ASC";
            }else
            {
                sql = "SELECT id_pr, name_pr, telf_number_pr, email_pr FROM proveder WHERE name_pr LIKE '%" + data + "%' OR telf_numer LIKE '%" + data + "%' ORDER BY name_pr ASC";
            }

            try
            {
                MySqlConnection connectionDB = base.connection();
                connectionDB.Open();

                MySqlCommand command = new MySqlCommand(sql, connectionDB);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Proveder _proveder = new Proveder
                    {
                        Id = int.Parse(reader.GetString(0)),
                        Name = reader.GetString(1),
                        TelfNumber = reader.GetString(2),
                        Email = reader.GetString(3)
                    };

                    list.Add(_proveder);
                }
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return list;
        }

        public bool insert(Proveder proveder)
        {
            bool check;

            string sql = "INSERT INTO proveder (id_pr, name_pr, telf_number_pr, email_pr) VALUES ('" + proveder.Id + "', '" + proveder.Name + "', '" + proveder.TelfNumber + "', '" + proveder.Email + "')";

            try
            {
                MySqlConnection connectionDB = base.connection();
                connectionDB.Open();
                MySqlCommand command = new MySqlCommand(sql, connectionDB);
                command.ExecuteNonQuery();
                check = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                check = false;
            }

            return check;
        }

        public bool upDate(Proveder proveder)
        {
            bool check;

            string sql = "UPDATE proveder SET name_pr='" + proveder.Name + "', telf_number_pr='" + proveder.TelfNumber + "', email_pr='" + proveder.Email + "' WHERE id_pr='"+proveder.Id+"'";

            try
            {
                MySqlConnection connectionDB = base.connection();
                connectionDB.Open();
                MySqlCommand command = new MySqlCommand(sql, connectionDB);
                command.ExecuteNonQuery();
                check = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                check = false;
            }

            return check;
        }

        public bool delete(string name)
        {
            bool check;
            
            string sql = "DELETE FROM proveder WHERE name_pr='" + name + "'";

            try
            {
                MySqlConnection connectionDB = base.connection();
                connectionDB.Open();
                MySqlCommand command = new MySqlCommand(sql, connectionDB);
                command.ExecuteNonQuery();                
                check = true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                check = false;
            }

            return check;
        }
    }
}
