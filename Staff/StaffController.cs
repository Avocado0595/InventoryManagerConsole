
namespace InventoryManagement.Staff
{
    public class StaffController
    {
        private Dictionary<string, Staff> staffList = new Dictionary<string, Staff>();
        private readonly DataService<string, Staff> staffService;

        public StaffController(DataService<string, Staff> staffService)
        {
            this.staffService = staffService;
            RefreshModel();
        }
        public int GetStaffCount()
        {
            return staffList.Count;
        }
        public void AddNewStaff(Staff p)
        {
            staffList.Add(p.Account, p);
            staffService.Write(staffList);
            //RefreshModel();
        }
        public void DeleteStaff(string account)
        {
            staffList.Remove(account);
            staffService.Write(staffList);
            //RefreshModel();
        }
        public Staff? Login(string account, string password)
        {
            try
            {
                if (!staffList.ContainsKey(account))
                {
                    throw new Exception("Tài khoản không tồn tại");
                }
                Staff p = staffList[account];
                if (!p.CheckPassword(password))
                    throw new Exception("Mật khẩu không đúng");
                return p;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
        public void GettAllStaff()
        {
            foreach (Staff p in staffList.Values)
            {
                Console.WriteLine(p);
            }
        }
        public Staff? GettStaffByAccount(string account)
        {
            if(staffList.ContainsKey(account)) { return staffList[account]; }
            return null;
        }
        public void UpdateRole(string account, ROLE role)
        {
            Staff p = staffList[account];
            p.Role = role;
            staffService.Write(staffList);
            //RefreshModel();
        }
        public void ChangePassword(string account, string newPassword)
        {
            Staff? p = staffList[account];
            if (p != null)
            {
                p.ChangePassword(newPassword);
                Console.WriteLine("Change password successfully!");
            }
            else
            {
                Console.WriteLine("Fail to change password!");
            }
            staffService.Write(staffList);
            //RefreshModel();

        }
        private void RefreshModel()
        {
            if (staffService.Read() != null)
                staffList = staffService.Read();
        }
    }
}
