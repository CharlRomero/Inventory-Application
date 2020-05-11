using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DppInventory
{
    class Proveder
    {
        private int id_pr;
        private string name_pr;        
        private string telfNumber_pr;
        private string email_pr;

        public int Id { get => id_pr; set => id_pr = value; }
        public string Name { get => name_pr; set => name_pr = value; }        
        public string TelfNumber { get => telfNumber_pr; set => telfNumber_pr = value; }
        public string Email { get => email_pr; set => email_pr = value; }

        public Proveder(){
        }
    }
}
