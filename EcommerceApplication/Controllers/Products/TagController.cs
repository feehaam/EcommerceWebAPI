using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagCRUD Tags;
        public TagController(ITagCRUD tags)
        {
            Tags = tags;
        }

        [HttpGet("/tags")]
        public IActionResult GetAllTags()
        {
            try
            {
                return Ok(Tags.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Error parsing the tags - "+ex.Message);
            }
        }
        [HttpPost("/tags/create")]
        public IActionResult CreateTag(int UserId, int CategoryId, Tag Tag)
        {
            try
            {
                bool result = Tags.Create(UserId, CategoryId, Tag);
                if(result)
                {
                    return Ok("Successfully created.");
                }
                else
                {
                    return StatusCode(500, "Server error during adding new tag.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error parsing the tags - " + ex.Message);
            }
        }
        [HttpGet("/tags/{TagId}")]
        public IActionResult Read(int TagId)
        {
            try
            {
                Tag Tag = Tags.Read(TagId);
                if (Tag.TagId != -1)
                {
                    return Ok(Tag);
                }
                else
                {
                    return StatusCode(500, "Tag doesn't exist with given ID.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error parsing the tag - " + ex.Message);
            }
        }
    }
}
