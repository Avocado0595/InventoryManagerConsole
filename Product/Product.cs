using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int Quantity { get; set; }
        public Product(int id, string name, int quantity, string description, int categoryId) { 
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return string.Format("ID: {0}\tTên: {1}\tSố lượng: {2}\tMô tả: {3}", Id, Name, Quantity, Description);
        }
    }
  
}
