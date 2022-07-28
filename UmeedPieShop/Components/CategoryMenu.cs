using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Components
{
    // component -> repository -> appdbcontext -> EFcore -> database
    public class CategoryMenu: ViewComponent // <<=== Equivalent to Controller
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke() // <<=== Equivalent to Action Method
        {
            return View(categoryRepository.AllCategories);
        }
    }

    // View Component Intract With Database directly
}
