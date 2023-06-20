using EcommerceApplication.IRepository.Orders;
using EcommerceApplication.Models.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderUpdateController : ControllerBase
    {
        private readonly IOrderRepoUpdate _update;

        public OrderUpdateController(IOrderRepoUpdate update)
        {
            _update = update;
        }

        [HttpGet("/order/payment/{orderId}")]
        public IActionResult Get(int orderId)
        {
            return Ok(_update.ReadPaymentStatus(orderId));
        }

        [HttpPost("/order/payment/add")]
        public IActionResult Add(int orderId, Payment payment)
        {
            if(_update.AddPayment(orderId, payment))
            {
                return Ok("Payment added.");
            }
            else
            {
                return BadRequest("Failed to add payment.");
            }
        }

        [HttpPut("/order/deliverystatus/update")]
        public IActionResult Update(int orderId, string status)
        {
            if (_update.UpdateDeliveryStatus(orderId, status))
            {
                return Ok("Status updated.");
            }
            else
            {
                return BadRequest("Failed to update status.");
            }
        }
    }
}
