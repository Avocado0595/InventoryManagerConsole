

namespace InventoryManagement
{
    public abstract class Person
    {
        private readonly string id;
        private string fullname;
        private string account;
        private string password;
        private string role;

        public string Id { get { return id; } }
        public string Fullname { get { return fullname; } set { fullname = value; } }
        public string Role { get { return role; } set { fullname = value; } }
        public string Account { get { return account; } set { account = value; } }
        public string Password { set { password = value; } }
        public bool IsRightPassword(string password)
        {
            return this.password.Equals(password);
        }
        public Person(string id, string fullname, string account, string password)
        {
            this.id = id;
            this.fullname = fullname;
            this.account = account;
            this.password = password;
        }

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t{2}\t{3}", id, account, fullname,role);
        }
    }
}
