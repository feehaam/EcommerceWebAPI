using EcommerceApplication.IRepository.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListsController : ControllerBase
    {
        private readonly IOrderRepoLists lists;

        public OrderListsController(IOrderRepoLists lists)
        {
            this.lists = lists;
        }

        [HttpGet("/orders")]
        public IActionResult Get()
        {
            return Ok(lists.GetAllOrders());
        }

        [HttpGet("/orders/{status}")]
        public IActionResult Get(string status)
        {
            return Ok(lists.GetOrdersByStatus(status));
        }

        [HttpGet("/orders/{userId:int}")]
        public IActionResult GetbyUID(int userId)
        {
            return Ok(lists.GetOrdersByUser(userId));
        }
    }
}
