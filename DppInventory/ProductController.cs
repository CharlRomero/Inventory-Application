using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DppInventory
{
    class ProductController
    {   
        public List<Product> query(string data)
        {
            MySqlDataReader reader;
            List<Product> list = new List<Product>();
            string sql;

            if(data == null)
            {
                sql = "SELECT id_p, name_p, stock_p, price_p FROM products ORDER BY name_p ASC";
            }else
            {
                sql = "SELECT id_p, name_p, stock_p, price_p FROM products WHERE id_p LIKE " +
                    "'%" + data+ "%' OR name_p LIKE '%" + data + "%' ORDER BY name_p ASC";
            }

            try
            {
                MySqlConnection connectionDB = Connection.connection();
                connectionDB.Open();

                MySqlCommand command = new MySqlCommand(sql, connectionDB);

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product _product = new Product();

                    _product.Id = reader.GetString(0);
                    _product.Name = reader.GetString(1);                    
                    _product.Stock = int.Parse(reader.GetString(2));
                    _product.Price = double.Parse(reader.GetString(3));

                    list.Add(_product);
                }
            }catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return list;
        }
            
    }
}
