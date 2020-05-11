using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DppInventory
{
    public interface ControllerRepository<T>
    {
        List<Object> Query(string data);        
        bool insert(T obj);
        bool upDate(T obj);
        bool delete(string id);
    }
}
