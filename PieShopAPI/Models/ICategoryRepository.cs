namespace PieShopAPI.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
        public Category InsertCategory(Category category);
        public Category UpdateCategory(Category category);
        public Category DeleteCategory(int categoryId);

    }
}
