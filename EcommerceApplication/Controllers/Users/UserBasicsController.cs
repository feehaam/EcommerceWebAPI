using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBasicsController : ControllerBase
    {
        private readonly IUserRepoBasics _repo;
        public UserBasicsController(IUserRepoBasics repo)
        {
            _repo = repo;
        }

        // List of all users
        [HttpGet("/users")]
        public IActionResult GetAllUsers()
        {
            try
            {
                ICollection<User> users = _repo.GetAllUsers();
                return Ok(users);
            }
            catch
            {
                return StatusCode(500, "An unexpected server error occurred.");
            }
        }
        [HttpGet("/user/exist/{id:int}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_repo.IfExists(id));
            }
            catch
            {
                return StatusCode(500, "An unexpected server error occurred.");
            }
        }
        [HttpGet("/user/exist/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            try
            {
                return Ok(_repo.IfExists(email));
            }
            catch
            {
                return StatusCode(500, "An unexpected server error occurred.");
            }
        }
    }
}
