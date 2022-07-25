using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            var pies = _pieRepository.AllPies;
            return View(pies);
        }
        public IActionResult PieOfWeek()
        {
            var piesOfWeek = _pieRepository.PiesOfTheWeek;
            return View(piesOfWeek);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            return View(pie);
        }

        public ViewResult Category1()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 1);
            var category = _categoryRepository.AllCategories.Where(c => c.CategoryId == 1);
            customeClass.CurrentCategory = category.Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = category.Select(c => c.Description).First();
            return View(customeClass);
        }
        public ViewResult Category2()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 2);
            var category = _categoryRepository.AllCategories.Where(c => c.CategoryId == 2);
            customeClass.CurrentCategory = category.Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = category.Select(c => c.Description).First();
            return View(customeClass);
        }
        public ViewResult Category3()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 3);
            var category = _categoryRepository.AllCategories.Where(c => c.CategoryId == 3);
            customeClass.CurrentCategory = category.Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = category.Select(c => c.Description).First();
            return View(customeClass);
        }

        public ViewResult FilterUp()
        {
            var pies = _pieRepository.AllPies.OrderBy(p=> p.Price);
            return View(pies);
        }

        public ViewResult FilterDown()
        {
            var pies = _pieRepository.AllPies.OrderByDescending(p => p.Price);
            return View(pies);
        }
        public ViewResult FilterName()
        {
            var pies = _pieRepository.AllPies.OrderBy(p => p.Name.ToUpper());
            return View(pies);
        }

        public ViewResult FilterStock()
        {
            var pies = _pieRepository.AllPies.Where(p => p.InStock);
            return View(pies);
        }
    }
}
