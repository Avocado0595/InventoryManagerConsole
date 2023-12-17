using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Admin:Person
    {
        public Admin(String id, string fullname, string account, string password) : base(id, fullname, account, password) {
            this.Role = ROLE.ADMIN;
        }
       

    }
}
