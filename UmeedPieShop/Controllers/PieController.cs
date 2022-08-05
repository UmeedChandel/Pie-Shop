using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration _configuration;
        string baseAddress;
        public PieController(IMapper mapper, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
            this.httpContextAccessor = httpContextAccessor;
        }

        private IEnumerable<Pie> GetAllPies()
        {
            var pies = StaticApiData.GetApiPieData(baseAddress + "Pie/AllPiesList");
            return pies.Result;
        }

        public IActionResult List(int id)
        {
            IEnumerable<Pie> pies;
            CustomeClass customeClass = new CustomeClass();
            if (id > 0)
            {
                pies = GetAllPies().Where(pie => pie.CategoryId == id);
                customeClass.CurrentCategory = "Category";
                customeClass.CategoryDescription = "";
            }
            else
            {
                pies = GetAllPies();
                customeClass.CurrentCategory = "List Of Pies";
                customeClass.CategoryDescription = "";
            }

            customeClass.Pies = pies;
            return View(customeClass);
        }

        [Authorize]
        public IActionResult ListMini()
        {
            var pies = GetAllPies();
            var piesmini = _mapper.Map<IEnumerable<PieMini>>(pies);
            return View(piesmini);
        }

        public IActionResult PieOfWeek()
        {
            var piesOfWeek = StaticApiData.GetApiPieData(baseAddress + "Pie/PieOfWeek");
            return View(piesOfWeek.Result);
        }

        
        public IActionResult Details(int id)
        {
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }


        // CRUD Operations

        public void CategoryItem()
        {
            var categories = StaticApiData.GetApiCategoryData(baseAddress + "Category/AllCategories");
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            foreach (var category in categories.Result)
            {
                categoryItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }
            ViewBag.categoryItems = categoryItems;
        }

        [Authorize]
        public ViewResult EditPie(int id)
        {
            CategoryItem();
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }

        public async Task<IActionResult> Update(Pie pie) //PutAsync
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync(baseAddress + "Crud/Update", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");
        }

        [Authorize]
        public ViewResult CreatePie()
        {
            CategoryItem();
            return View();
        }

        public async Task<IActionResult> Insert(Pie pie) //PostAsync
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync(baseAddress + "Crud/Insert", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");
        }

        [Authorize]
        public ViewResult DeletePie(int id)
        {
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }

        public async Task<IActionResult> Delete(int PieId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(baseAddress + "Crud/Delete?PieId=" + PieId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("List");
        }
    }
}
