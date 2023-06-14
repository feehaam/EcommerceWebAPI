using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryCRUD categories;
        public CategoriesController(ICategoryCRUD categories)
        {
            this.categories = categories;
        }

        [HttpPost("/category/create")]
        public IActionResult Create(int UserId, Category category)
        {
            if(categories.Create(UserId, category))
            {
                return Ok("Created succesfully.");
            }
            return BadRequest("Failed to add category");
        }
        [HttpGet("/category/{id:int}")]
        public IActionResult Read(int id)
        {
            var cat = categories.Read(id);
            if (cat == null)
            {
                return NotFound("Category not found");
            }
            else return Ok(cat);
        }
        [HttpGet("/category/{name}")]
        public IActionResult ReadByName(string name)
        {
            var cat = categories.Read(name);
            if (cat == null)
            {
                return NotFound("Category not found");
            }
            else return Ok(cat);
        }
        [HttpPut("/category/update")]
        public IActionResult Update(int UserId, Category category)
        {
            if (categories.Update(UserId, category))
            {
                return Ok("Update successfull.");
            }
            else return StatusCode(500, "Server error.");
        }
        [HttpDelete("/category/delete")]
        public IActionResult Delete(int UserId, int categoryId)
        {
            if (categories.Delete(UserId, categoryId))
            {
                return Ok("Category deleted.");
            }
            else return StatusCode(500, "Server error.");
        }
        [HttpGet("/category")]
        public IActionResult GetAll()
        {
            return Ok(categories.GetAll());
        }
        [HttpGet("/category/tags/{CategoryId}")]
        public IActionResult GetTags(int CategoryId)
        {
            return Ok(categories.GetTags(CategoryId));
        }

    }
}
