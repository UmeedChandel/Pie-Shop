using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public CategoryController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public ViewResult Category(int id)
        {

            IEnumerable<Pie> pies;
            if (id > 0)
            {
                pies = _pieRepository.AllPies.Where(pie => pie.CategoryId == id);
            }
            else
            {
                pies = _pieRepository.AllPies;
            }
      
            CustomeClass customeClass = new CustomeClass();
            customeClass.Pies = pies;

            if (id > 0)
            {
                customeClass.CurrentCategory = customeClass.Pies.First().Category.CategoryName;
                customeClass.CategoryDescription = customeClass.Pies.First().Category.Description;
            }
            else
            {
                customeClass.CurrentCategory = "PIES";
                customeClass.CategoryDescription = "List of all the Pies.";
            }
            
            return View(customeClass);
        }
    }
}
