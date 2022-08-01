using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Components
{
    // component -> repository -> appdbcontext -> EFcore -> database
    public class CategoryMenu : ViewComponent // <<=== Equivalent to Controller
    {
        private readonly IConfiguration _configuration;
        string baseAddress;
        public CategoryMenu(IConfiguration configuration)
        {
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
        }

        public async Task<IViewComponentResult> InvokeAsync() //<<=== Equivalent to Action Method
        {
            var category = StaticApiData.GetApiCategoryData(baseAddress + "Category/AllCategories");
            return View(category.Result);
        }
    }

    // View Component Intract With Database directly
}