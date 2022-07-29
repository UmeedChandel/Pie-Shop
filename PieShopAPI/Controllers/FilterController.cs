using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{
    [ApiController]
    [Route("api/Filter")]
    public class FilterController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;
        public FilterController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]
        [Route("PriceAsc")]
        public IActionResult FilterUp()
        {
            try
            {
                var pies = _pieRepository.AllPies.OrderBy(p => p.Price);
                return Ok(pies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
            
        }

        [HttpGet]
        [Route("PriceDesc")]
        public IActionResult FilterDown()
        {
            try
            {
                var pies = _pieRepository.AllPies.OrderByDescending(p => p.Price);
                return Ok(pies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
            
        }

        [HttpGet]
        [Route("ByName")]
        public IActionResult FilterName()
        {
            try
            {
                var pies = _pieRepository.AllPies.OrderBy(p => p.Name.ToUpper());
                return Ok(pies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
            
        }

        [HttpGet]
        [Route("ByStock")]
        public IActionResult FilterStock()
        {
            try
            {
                var pies = _pieRepository.AllPies.Where(p => p.InStock);
                return Ok(pies);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
            
        }
    }
}
