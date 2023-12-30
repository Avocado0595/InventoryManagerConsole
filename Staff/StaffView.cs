
using InventoryManagement.Category;
using InventoryManagement.Product;
using System.Text;

namespace InventoryManagement.Staff
{
    public class StaffView
    {
        private readonly StaffController staffController;
        private readonly ProductController productController;
        private readonly CategoryController categoryController;
        private Staff? currentStaff;
        private Screen? screen;
        public StaffView(StaffController staffController, CategoryController categoryController, ProductController productController)
        {
            Console.OutputEncoding = Encoding.UTF8;
            this.staffController = staffController;
            this.categoryController = categoryController;
            this.productController = productController;
            currentStaff = null;
            screen = null;
            MainView();
        }
        private void MainView()
        {
            while (true)
            {
                try
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
                                    if (currentStaff != null)
                                        Console.WriteLine("Đăng nhập thành công");
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
                        Action action = Action.NONE;
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
                            case Screen.CATEGORY_MANAGER:
                                {
                                    action = ViewSimulator.CategoryManagerMenu();
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                        if (action == Action.NONE) continue;
                        switch (action)
                        {
                            case Action.VIEW_ALL_STAFF:
                                {
                                    Console.WriteLine("Danh sách nhân viên");
                                    Console.WriteLine(string.Format("{0,-15}|{1,-30}|{2,-10}", "account", "tên nv", "role"));
                                    Console.WriteLine(new string('-', 57));
                                    this.staffController.GettAllStaff();
                                    break;
                                }
                            case Action.ADD_NEW_STAFF:
                                {
                                    Console.WriteLine("Thêm nhân viên mới");
                                    string account, password, fullname;
                                    ROLE role;
                                    ViewSimulator.CreateStaffForm(out account, out password, out fullname, out role);
                                    Staff staff = new Staff(account, password, fullname, role);
                                    this.staffController.AddNewStaff(staff);
                                    break;
                                }
                            case Action.LOG_OUT:
                                {
                                    Console.WriteLine("Đăng xuất");
                                    currentStaff = null;
                                    screen = null;
                                    break;
                                }
                            case Action.RETURN_HOME:
                                {
                                    screen = (Screen)currentStaff.Role;
                                    break;
                                }
                            case Action.CHANGE_PASS:
                                {
                                    Console.Write("Nhập mật khẩu mới: ");
                                    string password = Console.ReadLine();
                                    this.staffController.ChangePassword(currentStaff.Account, password);
                                    break;
                                }
                            case Action.DELETE_STAFF:
                                {
                                    Console.Write("Nhập id nhân viên cần xóa: ");
                                    string account = Console.ReadLine();
                                    this.staffController.DeleteStaff(account);
                                    break;
                                }
                            case Action.UPDATE_ROLE:
                                {
                                    Console.Write("Nhập account nhân viên cần thay role: ");
                                    string account = Console.ReadLine();
                                    Console.Write("Nhập role mới (0-admin, 1-manager, 2-staff): ");
                                    ROLE role = (ROLE)Int32.Parse(Console.ReadLine());
                                    staffController.UpdateRole(account, role);
                                    break;
                                }
                            case Action.ADD_NEW_CATEGORY:
                                {
                                    Console.WriteLine("Thêm danh mục");
                                    int id;
                                    string name;
                                    ViewSimulator.CreateCategoryForm(out id, out name);
                                    categoryController.AddCategory(new Category.Category(id, name));
                                    break;
                                }
                            case Action.VIEW_ALL_CATEGORY:
                                {
                                    Console.WriteLine("Danh sách danh mục");
                                    List<Category.Category> categoryList = categoryController.GetCategories();
                                    foreach (Category.Category c in categoryList)
                                    {
                                        Console.WriteLine(c);
                                    }

                                    break;
                                }
                            case Action.DELETE_CATEGORY:
                                {
                                    Console.Write("Nhập id cần xóa: ");
                                    int id = int.Parse(Console.ReadLine());
                                    categoryController.DeleteCategory(id);
                                    break;
                                }
                            case Action.UPDATE_CATEGORY:
                                {
                                    Console.Write("Nhập id cần update tên: ");
                                    int id = int.Parse(Console.ReadLine());
                                    Console.Write("Nhập tên cần update: ");
                                    string name = Console.ReadLine();
                                    categoryController.UpdateCategoryName(id, name);
                                    break;
                                }
                            //product
                            case Action.ADD_NEW_RPODUCT:
                                {
                                    Console.WriteLine("Thêm sản phẩm");
                                    int id, quantity, categoryId;
                                    string name, description;
                                    ViewSimulator.CreateProductForm(out id, out name, out description, out quantity, out categoryId);
                                    var checkCategory = categoryController.GetCategory(categoryId);
                                    if (checkCategory == null)
                                        categoryId = -1;
                                    productController.AddProduct(new Product.Product(id, name, quantity, description, categoryId));
                                    break;
                                }
                            case Action.VIEW_ALL_RPODUCT:
                                {
                                    Console.WriteLine("Danh sách sản phẩm");
                                    List<Product.Product> productList = productController.GetAllProduct();
                                    foreach (Product.Product p in productList)
                                    {
                                        Console.WriteLine(p);
                                    }

                                    break;
                                }
                            case Action.DELETE_RPODUCT:
                                {
                                    Console.Write("Nhập id cần xóa: ");
                                    int id = int.Parse(Console.ReadLine());
                                    productController.DeleteProduct(id);
                                    break;
                                }
                            case Action.UPDATE_PRODUCT_CATEGORY:
                                {
                                    Console.Write("Nhập id cần update tên: ");
                                    int id = int.Parse(Console.ReadLine());
                                    Console.Write("Nhập ID danh mục: ");
                                    int categoryId = int.Parse(Console.ReadLine());
                                    productController.UpdateCategoryProduct(id, categoryId);
                                    break;
                                }
                            case Action.PRODUCT_DETAIL: {
                                    Console.WriteLine("Chi tiết sản phẩm");
                                    Console.Write("Nhập ID sp: ");
                                    int id = int.Parse(Console.ReadLine());
                                    Product.Product? p = productController.GetProductById(id);
                                    if (p == null)
                                    {
                                        Console.WriteLine("Sản phẩm không tồn tại");
                                    }
                                    else
                                    {
                                        Console.WriteLine(p);
                                        Category.Category c = categoryController.GetCategory(p.CategoryId??0);
                                        if (c != null)
                                        {
                                            Console.WriteLine("Danh mục: " + c.Name);
                                        }
                                    }
                                    break;
                                }
                            case Action.PROBUCT_BY_CATEGORY: {
                                    Console.WriteLine("Xem sản phẩm theo danh mục");
                                    Console.Write("Nhập id danh mục: ");
                                    int id = int.Parse(Console.ReadLine());
                                    List<Product.Product> products = productController.GetAllProductByCategory(id);
                                    Category.Category c = categoryController.GetCategory(id);
                                    if (c == null)
                                    {
                                        Console.WriteLine("Danh mục không tồn tại");
                                        break;
                                    }
                                   
                                    if (products != null && products.Count > 0)
                                    {
                                        Console.WriteLine("Danh sách sp theo danh mục " + c.Name);
                                        foreach (Product.Product p in products) {
                                            Console.WriteLine(p);
                                        }

                                    }
                                    else {
                                        Console.WriteLine("Danh sách trống");  
                                    }
                                    break;
                                }
                            case Action.IMPORT_PRODUCT:
                                {
                                    Console.WriteLine("Nhập kho");
                                    Console.Write("Nhập id sp: ");
                                    int id = int.Parse(Console.ReadLine());
                                    Product.Product p = productController.GetProductById(id);
                                    if (p == null)
                                    {
                                        Console.WriteLine("Sản phẩm không tồn tại");
                                        break;
                                    }
                                    Console.Write("Số lượng nhập: ");
                                    int quantity = int.Parse(Console.ReadLine());
                                    if (quantity <= 0) {
                                        throw new Exception("Nhập số lượng nhỏ hơn 1");
                                       
                                    }
                                    productController.UpdateQuantityProduct(id, quantity);
                                    
                                    break;
                                }
                            case Action.EXPORT_PRODUCT:
                                {
                                    Console.WriteLine("Xuất kho");
                                    Console.Write("Nhập id sp: ");
                                    int id = int.Parse(Console.ReadLine());
                                    Product.Product p = productController.GetProductById(id);
                                    if (p == null)
                                    {
                                        Console.WriteLine("Sản phẩm không tồn tại");
                                        break;
                                    }

                                    Console.Write("Số lượng xuất: ");
                                    int quantity = int.Parse(Console.ReadLine());
                                    if (quantity <= 0)
                                    {
                                        throw new Exception("Nhập số lượng nhỏ hơn 1");

                                    }
                                    if (p.Quantity < quantity)
                                    {
                                        throw new Exception("Nhập số lượng vượt quá tồn kho");
                                    }
                                    productController.UpdateQuantityProduct(id, -quantity);

                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }

                }
                catch (Exception ex) {
                    Console.WriteLine("Ôi không, đã xảy ra lỗi");
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
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
