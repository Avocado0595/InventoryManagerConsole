using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Staff:Person
    {
        public Staff(String id, string fullname, string account, string password): base(id, fullname, account, password) {
            this.Role = ROLE.STAFF; 
        }
    

    }
}
