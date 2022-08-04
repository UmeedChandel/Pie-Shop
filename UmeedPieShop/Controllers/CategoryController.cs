using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        string baseAddress;
        public CategoryController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
            this.httpContextAccessor = httpContextAccessor;
        }

        // API connectivity for Category

        private IEnumerable<Category> AllCategories()
        {
            var Category = StaticApiData.GetApiCategoryData(baseAddress + "Category/AllCategories");
            return Category.Result;
        }
        public IActionResult CategoryList()
        {
            return View(AllCategories());
        }

        // CRUD Operations

        /*public RedirectToActionResult Crud()
        {
            var user = httpContextAccessor.HttpContext.User.Identity.Name;
            if (user == "manager@gmail.com")
            {
                return RedirectToAction("EditCategory");
            }
            return RedirectToAction("AuthRequire");
        }
        public ViewResult AuthRequire()
        {
            return View();
        }*/

        [Authorize]
        public ViewResult EditCategory(int id)
        {
            var category = AllCategories().FirstOrDefault(p => p.CategoryId == id);
            return View(category);
        }

        public async Task<IActionResult> Update(Category category) //PutAsync
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync(baseAddress + "Category/Update", category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("CategoryList");
        }

        [Authorize]
        public ViewResult CreateCategory()
        {
            return View();
        }

        public async Task<IActionResult> Insert(Category category) //PostAsync
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(baseAddress + "Category/Insert", category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("CategoryList");
        }

        [Authorize]
        public ViewResult DeleteCategory(int id)
        {
            var category = AllCategories().FirstOrDefault(p => p.CategoryId == id);
            return View(category);
        }

        public async Task<IActionResult> Delete(int CategoryId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(baseAddress + "Category/Delete?CategoryId=" + CategoryId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("CategoryList");
        }
    }
}
