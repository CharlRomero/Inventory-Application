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
        private Proveder proveder;
        private int stock;
        private double price;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Proveder Proveder { get => proveder; set => proveder = value; }
        public int Stock { get => stock; set => stock = value; }
        public double Price { get => price; set => price = value; }

        public Product(){
        }

    } 
}
