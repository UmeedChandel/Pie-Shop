using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Components
{
    // component -> repository -> appdbcontext -> EFcore -> database
    public class CategoryMenu : ViewComponent // <<=== Equivalent to Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IConfiguration _configuration;
        string baseAddress;
        public CategoryMenu(ICategoryRepository categoryRepository, IConfiguration configuration)
        {
            this.categoryRepository = categoryRepository;
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
        }
        public IViewComponentResult Invoke() // <<=== Equivalent to Action Method
        {
            //var category = StaticApiData1.GetApiData(baseAddress + "Pie/AllCategories");
            return View(categoryRepository.AllCategories);
        }
    }

    // View Component Intract With Database directly
}