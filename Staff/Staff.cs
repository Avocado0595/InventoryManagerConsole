
//Due to the naming of the library if the namespace is after the using statements the call changes as .net fails to resolve naming correctly I'd advise rather than enter the entire namespace you simply use the import aliasing as below.

using BC = BCrypt.Net.BCrypt;
using Newtonsoft.Json;
namespace InventoryManagement.Staff
{
    public class Staff
    {
        private string fullname;
        private readonly string account;
        [JsonProperty]
        private string password;
        private ROLE role;

        public string Fullname { get { return fullname; } set { fullname = value; } }
        public ROLE Role { get { return role; } set { role = value; } }
        public string Account { get { return account; } }

        public Staff(string account, string password, string fullname, ROLE role)
        {
            this.fullname = fullname;
            this.account = account;
            this.password = password;
            this.role = role;
        }
        public static string HashPassword(string password) {
            return BC.EnhancedHashPassword(password, hashType: BCrypt.Net.HashType.SHA384);
        }
        public bool CheckPassword(string password)
        {
            Console.WriteLine("\"" + password+"\"");
            Console.WriteLine("\"" + this.password + "\"");
            return BC.EnhancedVerify(password, this.password, hashType: BCrypt.Net.HashType.SHA384);
        }
        public void ChangePassword(string password) {
            this.password = HashPassword(password);
        }
        

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}", account, fullname,role);
        }
    }
}
