using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Category1()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 1);
            customeClass.CurrentCategory = customeClass.Pies.First().Category.CategoryName;
            customeClass.CategoryDescription = customeClass.Pies.First().Category.Description; 
            return View(customeClass);
        }
        public ViewResult Category2()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 2);
            customeClass.CurrentCategory = customeClass.Pies.First().Category.CategoryName;
            customeClass.CategoryDescription = customeClass.Pies.First().Category.Description;
            return View(customeClass);
        }
        public ViewResult Category3()
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == 3);
            customeClass.CurrentCategory = customeClass.Pies.First().Category.CategoryName;
            customeClass.CategoryDescription = customeClass.Pies.First().Category.Description;
            return View(customeClass);
        }

        public ViewResult Category(int id)
        {
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = _pieRepository.AllPies.Where(c => c.CategoryId == id);
            customeClass.CurrentCategory = customeClass.Pies.First().Category.CategoryName;
            customeClass.CategoryDescription = customeClass.Pies.First().Category.Description;
            return View(customeClass);
        }
    }
}
