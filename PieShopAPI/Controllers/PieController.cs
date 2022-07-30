using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{
    [ApiController]
    [Route("api/Pie")]
    public class PieController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _CategoryRepository;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _pieRepository = pieRepository;
            _CategoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("AllPiesList")]
        public IActionResult AllPiesList()
        {
            try
            {
                var pies = _pieRepository.AllPies;
                var ListMini = mapper.Map<ListMini[]>(pies);
                return Ok(ListMini);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpGet]
        [Route("PieOfWeek")]
        public IActionResult PieOfWeek()
        {
            try
            {
                var pies = _pieRepository.PiesOfTheWeek;
                var ListMini = mapper.Map<ListMini[]>(pies);
                return Ok(ListMini);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpGet("{id}", Name = "Details")]
        public IActionResult Details(int id)
        {
            try
            {
                var pie = _pieRepository.GetPieById(id);
                if (pie == null)
                {
                    return NotFound("No such Pie exist");
                }
                var DetailMini = mapper.Map<DetailMini>(pie);
                return Ok(DetailMini);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }



        [HttpGet]
        [Route("GetPiesByCategoryID")]
        public ActionResult<IEnumerable<Pie>> PiesByCategoryID(int categoryid = 1)
        {
            try
            {
                var pies = _pieRepository.AllPies.Where(p=> p.CategoryId== categoryid);

                if (pies == null)
                {
                    return NotFound("No such Pie in category exist");
                }

                return Ok(pies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        
        [HttpGet]
        [Route("AllCategories")]
        public IActionResult AllCategories()
        {
            try
            {
                return Ok(_CategoryRepository.AllCategories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }
    }
}
