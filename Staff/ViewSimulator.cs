using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Staff;
namespace InventoryManagement.Staff
{
    public class ViewSimulator
    {
        private static string PasswordInput()
        {
            string password = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return password;
        }
            public static void LoginForm(out string account, out string password)
        {
            Console.WriteLine("Đăng nhập");
            Console.Write("Account: ");
            account = Console.ReadLine();
            Console.Write("Password: ");
            password = PasswordInput();
            Console.WriteLine();
        }
        public static void CreateAdminForm(out string account, out string password, out string fullname)
        {
            Console.Write("Account: ");
            account = Console.ReadLine();
            Console.Write("Password: ");
            password  = Staff.HashPassword(PasswordInput());
            Console.WriteLine();
            Console.Write("Fullname: ");
            fullname = Console.ReadLine();
        }
        public static void CreateStaffForm(out string account, out string password, out string fullname, out ROLE role)
        {
            Console.Write("Account: ");
            account = Console.ReadLine();
            Console.Write("Password: ");
            password = Staff.HashPassword(PasswordInput());
            Console.WriteLine();
            Console.Write("Fullname: ");
            fullname = Console.ReadLine();
            Console.Write("Role (0-admin, 1-manager, 2-staff): ");
            role = (ROLE)Int32.Parse(Console.ReadLine());
        }
        public static void HomeView()
        {
            Console.WriteLine("Đăng nhập để tiếp tục");
            Console.WriteLine("1. Đăng nhập");
            Console.WriteLine("0. Thoát");
        }
        public static Action? AdminMenu(out Screen? screen)
        {
            //admin menu
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Quản lý nhân viên");
            Console.WriteLine("2. Quản lý hàng hóa");
            Console.WriteLine("3. Đổi mật khẩu");
            Console.WriteLine("0. Đăng xuất");
            int option = Int32.Parse(Console.ReadLine());
            screen = Screen.ADMIN;
            switch (option) {
                case 1:
                    {
                        screen = Screen.STAFF_MANAGER;
                        return null;
                    }
                case 2:
                    {
                        screen = Screen.PRODUCT_MANAGER;
                        return null;
                    }
                case 3: {
                        Console.WriteLine("Nhập mật khẩu mới: ");
                        return Action.CHANGE_PASS;
                    }
                default: {
                        return Action.LOG_OUT;
                    }
            }
        }
        public static Action? StaffMenu(out Screen? screen)
        {
            //admin menu
            Console.WriteLine("Staff Menu");
            Console.WriteLine("1. Quản lý hàng hóa");
            Console.WriteLine("2. Đổi mật khẩu");
            Console.WriteLine("0. Đăng xuất");
            int option = Int32.Parse(Console.ReadLine());
            screen = Screen.ADMIN;
            switch (option)
            {
                case 1:
                    {
                        screen = Screen.PRODUCT_MANAGER;
                        return null;
                    }
                case 2:
                    {
                        Console.WriteLine("Nhập mật khẩu mới: ");
                        return Action.CHANGE_PASS;
                    }
                default:
                    {
                        return Action.LOG_OUT;
                    }
            }
        }

        public static Action StaffManagerMenu()
        {
            Console.WriteLine("Quản lý nhân viên");
            Console.WriteLine("1. Xem danh sách");
            Console.WriteLine("2. Thêm");
            Console.WriteLine("3. Xóa");
            Console.WriteLine("4. Cập nhật role");
            Console.WriteLine("0. Back to home");
            int option = int.Parse(Console.ReadLine());
            switch (option) {
                case 1: return Action.VIEW_ALL_STAFF;
                case 2: return Action.ADD_NEW_STAFF;
                case 3: return Action.DELETE_STAFF;
                case 4: return Action.UPDATE_ROLE;
                default: return Action.RETURN_HOME;
            }
            
        }
        public static Action ProductManagerMenu()
        {
            Console.WriteLine("Quản lý hàng hóa");
            Console.WriteLine("1. Xem danh sách");
            Console.WriteLine("2. Thêm");
            Console.WriteLine("3. Xóa");
            Console.WriteLine("4. Cập nhật");
            Console.WriteLine("0. Back to home");
            int option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    {

                        return Action.NONE;
                    }
                default:
                    {
                        return Action.NONE;
                    }
            }
        }
    }
}
