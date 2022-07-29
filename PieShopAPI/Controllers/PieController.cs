using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{
    [ApiController]
    [Route("api/Pie")]
    public class PieController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _CategoryRepository;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _CategoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            try
            {
                return Ok(_pieRepository.AllPies);
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
                return Ok(_pieRepository.PiesOfTheWeek);
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
                return Ok(pie);
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

                if (Category == null)
                {
                    return NotFound("No such Category exist");
                }

                return Ok(pies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpGet]
        [Route("GetCategory")]
        public ActionResult<Category> Category(int categoryid = 1)
        {
            try
            {
                var Category = _CategoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == categoryid);

                if (Category == null)
                {
                    return NotFound("No such Category exist");
                }

                return Ok(Category);
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
