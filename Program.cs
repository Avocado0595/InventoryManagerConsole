using InventoryManagement.Category;
using InventoryManagement.Product;
using InventoryManagement.Staff;
using InventoryManagement.View;
namespace InventoryManagement
{
    class Program
    {
       
        public static void Main(string[] args)
        {
            
            DataService<string, Staff.Staff> staffService = new DataService<string, Staff.Staff>("staff.json");
            DataService<int, Category.Category> categoryService = new DataService<int, Category.Category>("category.json");
            DataService<int, Product.Product> productService = new DataService<int, Product.Product>("product.json");

            StaffController staffController = new StaffController(staffService);
            CategoryController categoryController = new CategoryController(categoryService);
            ProductController productController = new ProductController(productService);
            
            new MainView(staffController, categoryController, productController);
            
        }
    }
}
