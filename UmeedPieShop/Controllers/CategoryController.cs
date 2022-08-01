using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IConfiguration _configuration;
        string baseAddress;
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
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
