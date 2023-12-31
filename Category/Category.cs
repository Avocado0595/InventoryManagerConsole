
namespace InventoryManagement.Category
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString() {
            return string.Format("ID: {0}\tName: {1}", Id, Name);
        }
    }
}
