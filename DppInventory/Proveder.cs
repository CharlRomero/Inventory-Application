using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DppInventory
{
    class Proveder
    {
        private string name;
        private Product product;
        private string telfNumber;
        private string email;

        public string Name { get => name; set => name = value; }
        public Product Product { get => product; set => product = value; }
        public string TelfNumber { get => telfNumber; set => telfNumber = value; }
        public string Email { get => email; set => email = value; }

        public Proveder(){
        }
    }
}
