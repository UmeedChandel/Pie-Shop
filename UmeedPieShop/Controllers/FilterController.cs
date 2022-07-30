using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Controllers
{
    public class FilterController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public FilterController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [Authorize]
        public ViewResult FilterUp()
        {
            var pies = _pieRepository.AllPies.OrderBy(p => p.Price);
            return View(pies);
        }

        [Authorize]
        public ViewResult FilterDown()
        {
            var pies = _pieRepository.AllPies.OrderByDescending(p => p.Price);
            return View(pies);
        }

        [Authorize]
        public ViewResult FilterName()
        {
            var pies = _pieRepository.AllPies.OrderBy(p => p.Name.ToUpper());
            return View(pies);
        }

        [Authorize]
        public ViewResult FilterStock()
        {
            var pies = _pieRepository.AllPies.Where(p => p.InStock);
            return View(pies);
        }
    }
}
