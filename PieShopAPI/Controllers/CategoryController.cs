﻿using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{
    [ApiController]
    [Route("api/Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("CategoryById")]
        public ActionResult<Category> CategoryById(int categoryid = 1)
        {
            try
            {
                var Category = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryId == categoryid);

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
                return Ok(_categoryRepository.AllCategories);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert(Category category)
        {
            try
            {
                var insertedCategory = _categoryRepository.InsertCategory(category);
                return Ok(insertedCategory);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Category category)
        {
            try
            {
                var updatedCategory = _categoryRepository.UpdateCategory(category);
                return Ok(updatedCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int CategoryId)
        {
            try
            {
                var Category = _categoryRepository.AllCategories.FirstOrDefault(a => a.CategoryId == CategoryId);
                if (Category == null)
                {
                    return BadRequest("No such Category exist");
                }
                var deleteCategory = _categoryRepository.DeleteCategory(CategoryId);
                return Ok(deleteCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
    }

}
