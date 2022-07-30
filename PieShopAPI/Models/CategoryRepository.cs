namespace PieShopAPI.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;

        public Category InsertCategory(Category category)
        {
            var entry = _appDbContext.Categories.Add(category);
            _appDbContext.SaveChanges();
            return entry.Entity;
        }
        public Category UpdateCategory(Category category)
        {
            var entry = _appDbContext.Categories.Update(category);
            _appDbContext.SaveChanges();
            return entry.Entity;
        }
        public Category DeleteCategory(int categoryId)
        {
            var category = AllCategories.FirstOrDefault(a => a.CategoryId == categoryId);
            var entry = _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();
            return entry.Entity;
        }
    }
}
