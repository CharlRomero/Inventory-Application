using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DppInventory
{
    class Product
    {
        private string id;
        private string name;        
        private int stock;
        private double price;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }        
        public int Stock { get => stock; set => stock = value; }
        public double Price { get => price; set => price = value; }

        public Product(){
        }

        public string generateId(string name)
        {
            string[] words = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string id = "";

            for(int i = 0; i < words.Length; i++)
            {
                if(id.Length < 4)
                {
                    id += words[i].Substring(0, 1);
                }
            }

            id = id.ToUpper();

            return id;
        }
    } 
}
