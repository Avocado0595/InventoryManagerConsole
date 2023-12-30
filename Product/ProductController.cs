using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Product
{
    public class ProductController
    {
        private Dictionary<int, Product> _products = new Dictionary<int, Product>();
        private readonly DataService<int, Product> productService;
        public ProductController(DataService<int, Product> productService) {
            this.productService = productService;
            RefreshData();
        }
        private void RefreshData()
        {
            if (productService.Read() != null)
                _products = productService.Read();
        }
        public Product? GetProductById(int productId)
        {
            if(_products.ContainsKey(productId))
                return _products[productId];
            return null;
        }
        public List<Product> GetAllProduct()
        {
            return _products.Values.ToList();
        }
        public List<Product> GetAllProductByCategory(int categoryId)
        {
            return _products.Values.ToList().FindAll(p=>p.CategoryId == categoryId);
        }
        public void AddProduct(Product product)
        {
            _products.Add(product.Id, product);
            productService.Write(_products);
        }
        public void DeleteProduct(int productId) {
            _products.Remove(productId);
            productService.Write(_products);
        }


        public void UpdateQuantityProduct(int productId,int quantity)
        {
            _products[productId].Quantity += quantity;
            productService.Write(_products);
        }
        public void UpdateCategoryProduct(int productId, int categoryId)
        {
            _products[productId].CategoryId = categoryId;
            productService.Write(_products);
        }


    }
}
