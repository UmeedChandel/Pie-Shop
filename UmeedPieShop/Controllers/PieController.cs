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

        [HttpGet]
        [Route("Pie/Detail/{id:int}")]
        public IActionResult Detail(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            return View(pie);
        }

        public IActionResult Category1()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 1);
            customeClass.CurrentCategory = _categoryRepository.AllCategories.Where(c => c.CategoryId == 1).Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = _categoryRepository.AllCategories.Where(c => c.CategoryId == 1).Select(c=> c.Description).First();
            return View(customeClass);
        }

        public IActionResult Category2()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 2);
            customeClass.CurrentCategory = _categoryRepository.AllCategories.Where(c => c.CategoryId == 2).Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = _categoryRepository.AllCategories.Where(c => c.CategoryId == 2).Select(c => c.Description).First();
            return View(customeClass);
        }

        public IActionResult Category3()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 3);
            customeClass.CurrentCategory = _categoryRepository.AllCategories.Where(c => c.CategoryId == 3).Select(c => c.CategoryName).First();
            customeClass.CategoryDescription = _categoryRepository.AllCategories.Where(c => c.CategoryId == 3).Select(c => c.Description).First();
            return View(customeClass);
        }



        //action method for home page - listing all the pies of the week
        //action method for details page 

    }
}
