namespace InventoryManagement.Staff
{
    public class ViewSimulator
    {
        #region Staff
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
            password = Staff.HashPassword(PasswordInput());
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
        public static Action AdminMenu(out Screen? screen)
        {
            //admin menu
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Quản lý nhân viên");
            Console.WriteLine("2. Quản lý hàng hóa");
            Console.WriteLine("3. Quản lý danh mục");
            Console.WriteLine("4. Đổi mật khẩu");
            Console.WriteLine("0. Đăng xuất");
            int option = Int32.Parse(Console.ReadLine());
            screen = Screen.ADMIN;
            switch (option)
            {
                case 1:
                    {
                        screen = Screen.STAFF_MANAGER;
                        return Action.NONE;
                    }
                case 2:
                    {
                        screen = Screen.PRODUCT_MANAGER;
                        return Action.NONE;
                    }
                case 3:
                    {
                        screen = Screen.CATEGORY_MANAGER;
                        return Action.NONE;
                    }
                case 4:
                    {
                        Console.WriteLine("Nhập mật khẩu mới: ");
                        return Action.CHANGE_PASS;
                    }
                case 0: return Action.LOG_OUT;
                default: return Action.NONE;

            }
        }
        public static Action StaffMenu(out Screen? screen)
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
                        return Action.NONE;
                    }
                case 2: return Action.CHANGE_PASS;

                case 0: return Action.LOG_OUT;
                default: return Action.NONE;

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
            switch (option)
            {
                case 1: return Action.VIEW_ALL_STAFF;
                case 2: return Action.ADD_NEW_STAFF;
                case 3: return Action.DELETE_STAFF;
                case 4: return Action.UPDATE_ROLE;
                default: return Action.RETURN_HOME;
            }

        }

        #endregion
        #region Category
        public static void CreateCategoryForm(out int id, out string name)
        {
            Console.Write("ID: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Tên loại: ");
            name = Console.ReadLine();
        }
        public static Action CategoryManagerMenu()
        {
            Console.WriteLine("Quản lý danh mục");
            Console.WriteLine("1. Xem danh sách danh mục");
            Console.WriteLine("2. Thêm");
            Console.WriteLine("3. Xóa");
            Console.WriteLine("4. Cập nhật");
            Console.WriteLine("0. Back to home");
            int option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: return Action.VIEW_ALL_CATEGORY;
                case 2: return Action.ADD_NEW_CATEGORY;
                case 3: return Action.DELETE_CATEGORY;
                case 4: return Action.UPDATE_CATEGORY;
                default: return Action.RETURN_HOME;

            }

        }
        #endregion
        #region Product
        public static Action ProductManagerMenu()
        {
            Console.WriteLine("Quản lý hàng hóa");
            Console.WriteLine("1. Xem danh sách");
            Console.WriteLine("2. Xem chi tiết sp");
            Console.WriteLine("3. Xem danh sách sp theo danh mục");
            Console.WriteLine("4. Thêm");
            Console.WriteLine("5. Xóa");
            Console.WriteLine("6. Cập nhật danh mục");
            Console.WriteLine("7. Xuất/Nhập kho");
            Console.WriteLine("0. Back to home");
            int option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: return Action.VIEW_ALL_RPODUCT;
                case 2: return Action.PRODUCT_DETAIL;
                case 3: return Action.PROBUCT_BY_CATEGORY;
                case 4: return Action.ADD_NEW_RPODUCT;
                case 5: return Action.DELETE_RPODUCT;
                case 6: return Action.UPDATE_PRODUCT_CATEGORY;
                case 7: return ProductTransactionMenu();
                case 0: return Action.RETURN_HOME;
                default: return Action.NONE;

            }
        }
        public static Action ProductTransactionMenu()
        {
            Console.WriteLine("Nhập/Xuất hàng hóa");
            Console.WriteLine("1. Nhập kho");
            Console.WriteLine("2. Xuất kho");
            Console.WriteLine("0. Back to home");
            int option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                case 1: return Action.IMPORT_PRODUCT;
                case 2: return Action.EXPORT_PRODUCT;
                case 0: return Action.RETURN_HOME;
                default: return Action.NONE;

            }
        }

        public static void CreateProductForm(out int id, out string name, out string description, out int quantity, out int categoryId)
        {
            Console.Write("ID: ");
            id = int.Parse(Console.ReadLine());
            Console.Write("Tên sp: ");
            name = Console.ReadLine();
            Console.Write("Số lượng: ");
            quantity = int.Parse(Console.ReadLine());
            Console.Write("Danh mục (xem ds danh mục để lấy id): ");
            categoryId = int.Parse(Console.ReadLine());
            Console.Write("Mô tả: ");
            description = Console.ReadLine();
        }
        #endregion
    }
}
