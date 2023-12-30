using InventoryManagement.Category;
using InventoryManagement.Product;
using InventoryManagement.Staff;
using Newtonsoft.Json;
using System.Buffers;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
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
            
            new StaffView(staffController, categoryController, productController);
            
        }
    }
}
