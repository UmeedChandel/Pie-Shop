using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPieRepository _pieRepository;
        public PieController(IPieRepository pieRepository, IMapper mapper)
        {
            _pieRepository = pieRepository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var pies = _pieRepository.AllPies;
            return View(pies);
        }

        public IActionResult ListMini()
        {

            var pies = _pieRepository.AllPies;
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
            var pie = _pieRepository.GetPieById(id);
            return View(pie);
        }     
    }
}
