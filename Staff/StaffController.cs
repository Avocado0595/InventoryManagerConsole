using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Staff
{
    public class StaffController
    {
        private Dictionary<string, Staff> staffList = new Dictionary<string, Staff>();
        private readonly StaffModel staffModel;

        public StaffController(StaffModel staffModel)
        {
            this.staffModel = staffModel;
            RefreshModel();
        }
        public int GetStaffCount()
        {
            return staffList.Count;
        }
        public void AddNewStaff(Staff p)
        {
            staffList.Add(p.Account, p);
            staffModel.Write(staffList);
            RefreshModel();
        }
        public void DeleteStaff(string account)
        {
            staffList.Remove(account);
            staffModel.Write(staffList);
            RefreshModel();
        }
        public Staff? Login(string account, string password)
        {
            try
            {
                if (staffList == null || staffList[account] == null)
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
        public void UpdateRole(string account, ROLE role)
        {
            Staff p = staffList[account];
            p.Role = role;
            staffModel.Write(staffList);
            RefreshModel();
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
            staffModel.Write(staffList);
            RefreshModel();

        }
        private void RefreshModel()
        {
            if (staffModel.Read() != null)
                staffList = staffModel.Read();
        }
    }
}
