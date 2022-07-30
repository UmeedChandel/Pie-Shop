using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{
    [ApiController]
    [Route("api/Crud")]
    public class CrudController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;
        public CrudController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]
        [Route("PieById")]
        public IActionResult PieById(int id)
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

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Pie pie)
        {
            try
            {
                var insertedPie = _pieRepository.InsertPie(pie);
                return CreatedAtRoute("PieById", new { id = insertedPie.PieId }, insertedPie);
                //Ok(insertedPie);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Pie pie)
        {
            try
            {
                var updatedPie = _pieRepository.UpdatePie(pie);
                return CreatedAtRoute("PieById", new { id = updatedPie.PieId }, updatedPie);
                //Ok(updatedPie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int PieId)
        {
            try
            {
                var pie = _pieRepository.AllPies.FirstOrDefault(a => a.PieId == PieId);
                if (pie == null)
                {
                    return BadRequest("No such pie exist");
                }
                var deletePie = _pieRepository.DeletePie(PieId);
                return Ok(deletePie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

    }
}
