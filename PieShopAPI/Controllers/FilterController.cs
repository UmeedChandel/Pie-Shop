using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{
    [ApiController]
    [Route("api/Filter")]
    public class FilterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPieRepository _pieRepository;
        public FilterController(IPieRepository pieRepository, IMapper mapper)
        {
            _pieRepository = pieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("PriceAsc")]
        public IActionResult FilterUp()
        {
            try
            {
                var pies = _pieRepository.AllPies.OrderBy(p => p.Price);
                /*var FilterMini = _mapper.Map<FilterMini[]>(pies);
                return Ok(FilterMini);*/
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
                /*var FilterMini = _mapper.Map<FilterMini[]>(pies);
                return Ok(FilterMini);*/
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
                /*var FilterMini = _mapper.Map<FilterMini[]>(pies);
                return Ok(FilterMini);*/
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
                var FilterMini = _mapper.Map<FilterMini[]>(pies);
                return Ok(FilterMini);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
            
        }
    }
}
