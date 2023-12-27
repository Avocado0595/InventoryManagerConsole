
using System.Text;

namespace InventoryManagement.Staff
{
    public class StaffView
    {
        private readonly StaffController staffController;
        private Staff? currentStaff;
        private Screen? screen;
        public StaffView(StaffController staffController)
        {
            Console.OutputEncoding = Encoding.UTF8;
            this.staffController = staffController;
            currentStaff = null;
            screen = null;
            MainView();
        }
        private void MainView()
        {
            while (true)
            {
                
                if (staffController.GetStaffCount() == 0)
                {
                    staffController.AddNewStaff(InitAdmin());
                }
                else
                if (currentStaff == null)
                {
                    ViewSimulator.HomeView();
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            {
                                string account, password;
                                ViewSimulator.LoginForm(out account, out password);
                                currentStaff = staffController.Login(account, password);
                                break;
                            }
                        default:
                            {
                                return;
                            }
                    }
                }
                else
                {
                    if (screen == null)
                        screen = (Screen?)currentStaff.Role;
                    Action? action = null;
                    switch (screen)
                    {
                        case Screen.ADMIN:
                        case Screen.MANAGER:
                            {
                                action = ViewSimulator.AdminMenu(out screen);
                                break;
                            }
                        case Screen.STAFF:
                            {
                                action = ViewSimulator.StaffMenu(out screen);
                                break;
                            }
                        case Screen.STAFF_MANAGER:
                            {
                                action = ViewSimulator.StaffManagerMenu();
                                break;
                            }
                        case Screen.PRODUCT_MANAGER:
                            {
                                action = ViewSimulator.ProductManagerMenu();
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                    if (action == null) continue;
                    switch (action) {
                        case Action.VIEW_ALL_STAFF: {
                                this.staffController.GettAllStaff();
                                break;
                            }
                        case Action.ADD_NEW_STAFF:
                            {
                                string account, password, fullname;
                                ROLE role;
                                ViewSimulator.CreateStaffForm(out account, out password, out fullname, out role);
                                Staff staff = new Staff(account, password, fullname, role);
                                this.staffController.AddNewStaff(staff);
                                break;
                            }
                        case Action.LOG_OUT: {
                                currentStaff = null;
                                break;
                            }
                        case Action.RETURN_HOME: {
                                screen = (Screen)currentStaff.Role;
                                break;
                            }
                        case Action.CHANGE_PASS: {
                                string password = Console.ReadLine();
                                this.staffController.ChangePassword(currentStaff.Account, password);
                                break;
                            }
                        case Action.DELETE_STAFF: { 
                                string account = Console.ReadLine();
                                this.staffController.DeleteStaff(account);
                                break;
                            }
                        case Action.UPDATE_ROLE:
                            {
                                ROLE role = (ROLE)int.Parse(Console.ReadLine());
                                staffController.UpdateRole(currentStaff.Account, role);
                                break;
                            }
                        default: {
                                break;
                            }
                    }
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static Staff InitAdmin()
        {
            Console.WriteLine("Khởi tạo lần đầu. Tạo tài khoản admin");
            string account, password, fullname;
            ViewSimulator.CreateAdminForm(out account, out password, out fullname);
            return new Staff(account, password, fullname, ROLE.ADMIN);
        }
    }
}
