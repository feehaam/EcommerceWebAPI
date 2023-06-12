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
                ICollection<Tag> result = Tags.GetAll();
                return Ok(result);
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
        [HttpPut("/tags/update")]
        public IActionResult Update(int UserId, Tag Tag)
        {
            try
            {
                bool result = Tags.Update(UserId, Tag);
                if (result)
                {
                    return Ok("Updated succesfully.");
                }
                else
                {
                    return StatusCode(500, "Error in update, possible reason: invalid input.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Server error updating the tag - " + ex.Message);
            }
        }
        [HttpDelete("/tags/delete")]
        public IActionResult Delete(int UserId, int TagId)
        {
            try
            {
                bool result = Tags.Delete(UserId, TagId);
                if (result)
                {
                    return Ok("Deleted succesfully.");
                }
                else
                {
                    return StatusCode(500, "Error in delete, possible reason: invalid input.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Server error deleting the tag - " + ex.Message);
            }
        }
    }
}
