using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class PieController: Controller
    {
        private readonly IPieRepository _pieRepository;
        //private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            //_categoryRepository = categoryRepository;
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

        //action method for home page - listing all the pies of the week
        //action method for details page 

    }
}
