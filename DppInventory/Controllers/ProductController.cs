using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DppInventory
{
    class ProductController : Connection, ControllerRepository<Product>
    {
        public List<Object> Query(string data)
        {
            MySqlDataReader reader;
            List<Object> list = new List<Object>();
            string sql;

            if (data == null)
            {
                sql = "SELECT id_p, name_p, stock_p, price_p FROM products ORDER BY name_p ASC";
            } else
            {
                sql = "SELECT id_p, name_p, stock_p, price_p FROM products WHERE id_p LIKE " +
                    "'%" + data + "%' OR name_p LIKE '%" + data + "%' ORDER BY name_p ASC";
            }

            try
            {
                MySqlConnection connectionDB = base.connection();
                connectionDB.Open();

                MySqlCommand command = new MySqlCommand(sql, connectionDB);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product _product = new Product
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        Stock = int.Parse(reader.GetString(2)),
                        Price = double.Parse(reader.GetString(3))
                    };

                    list.Add(_product);
                }
            } catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return list;
        }

        public bool insert(Product product)
        {
            bool check = false;

            string sql = "INSERT INTO proveder (id_p, name_p, stock_p, price_p) VALUES ('"+ product.Id + "', '" + product.Name + "', " +
                "'" + product.Stock + "', '" + product.Price + "')";

            try
            {
                MySqlConnection connectionDB = base.connection();
                connectionDB.Open();
                MySqlCommand command = new MySqlCommand(sql, connectionDB);
                command.ExecuteNonQuery();
                check = true;
            }catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
                check = false;
            }

            return check;
        }

        public bool upDate(Product product)
        {
            bool check = false;

            string sql = "UPDATE proveder SET name_p = '" + product.Name + "', stock_p = '" + product.Stock + "', " +
                "price_p = '" + product.Price + "' WHERE id_p = '" + product.Id + "'";

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

        public bool delete(string id)
        {
            bool check = false;

            string sql = "DELETE FROM proveder WHERE id_p = '" + id + "'";

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
