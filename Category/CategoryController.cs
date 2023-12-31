namespace InventoryManagement.Category
{
    public class CategoryController
    {
        private Dictionary<int, Category> _categories = new Dictionary<int, Category>();
        private readonly DataService<int, Category> categoryService;
        public CategoryController(DataService<int, Category> categoryService) {
            this.categoryService = categoryService;
            RefreshData();
        }
        private void RefreshData()
        {
            if (categoryService.Read() != null)
                _categories = categoryService.Read();
        }
        public void AddCategory(Category category) { 
            _categories.Add(category.Id, category);
            categoryService.Write(_categories);
        }
        public void DeleteCategory(int id) { 
            _categories.Remove(id);
            categoryService.Write(_categories);
        }
        public Category? GetCategory(int id)
        {
            if(_categories.ContainsKey(id))
                return _categories[id];
            return null;
        }
        public void UpdateCategoryName(int id, string name)
        {
            if (_categories.ContainsKey(id))
            {
                _categories[id].Name = name;
            }
            else
            {
                throw new Exception("Category không tồn tại!");
            }
            categoryService.Write(_categories);
        }
        public List<Category> GetCategories()
        {
            return _categories.Values.ToList();
        }
    }
}
