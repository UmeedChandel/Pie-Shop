using AutoMapper;
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
                customeClass.CurrentCategory = "List Of Pies";
                customeClass.CategoryDescription = "";
            }

            return View(customeClass);
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
