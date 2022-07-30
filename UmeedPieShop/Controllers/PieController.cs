using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

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

        public IActionResult List(int id)
        {
            IEnumerable<Pie> pies;
            CustomeClass customeClass = new CustomeClass();
            if (id > 0)
            {
                pies = _pieRepository.AllPies.Where(pie => pie.CategoryId == id);
                customeClass.CurrentCategory = pies.First().Category.CategoryName;
                customeClass.CategoryDescription = pies.First().Category.Description;
            }
            else
            {
                pies = _pieRepository.AllPies;
                customeClass.CurrentCategory = "List Of Pies";
                customeClass.CategoryDescription = "";
            }

            customeClass.Pies = pies;
            return View(customeClass);
        }

        [Authorize]
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

        [Authorize]
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            return View(pie);
        }     
    }
}
