using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class PieMVCController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        string baseAddress;
        public PieMVCController(IMapper mapper, IConfiguration configuration, IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        private IEnumerable<Pie> GetAllPies()
        {
            var pies = _pieRepository.AllPies;
            return pies;
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
            var piesOfWeek = _pieRepository.PiesOfTheWeek;
            return View(piesOfWeek);
        }

        
        public IActionResult Details(int id)
        {
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }


        // CRUD Operations

        public void CategoryItem()
        {
            var categories = _categoryRepository.AllCategories;
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categoryItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }
            ViewBag.categoryItems = categoryItems;
        }
        
        [Authorize]
        public ViewResult CreatePie()
        {
            CategoryItem();
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Pie pie)
        {
            _pieRepository.InsertPie(pie);
            return RedirectToAction("List");
        }

        [Authorize]
        public ViewResult EditPie(int id)
        {
            CategoryItem();
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }

        [HttpPut]
        public IActionResult Update(Pie pie)
        {
            _pieRepository.UpdatePie(pie);
            return RedirectToAction("List");
        }

        [Authorize]
        public ViewResult DeletePie(int id)
        {
            var pie = GetAllPies().FirstOrDefault(p => p.PieId == id);
            return View(pie);
        }

        [HttpDelete]
        public IActionResult Delete(int PieId)
        {
            var pie = _pieRepository.AllPies.FirstOrDefault(a => a.PieId == PieId);
            var deletePie = _pieRepository.DeletePie(PieId);
            return RedirectToAction("List");
        }

    }
}
