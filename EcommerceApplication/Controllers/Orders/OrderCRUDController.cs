using EcommerceApplication.DTO.Orders;
using EcommerceApplication.IRepository.Orders;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.IRepository.Users;
using EcommerceApplication.Models.Orders;
using EcommerceApplication.Models.Products;
using EcommerceApplication.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCRUDController : ControllerBase
    {
        private readonly IOrderRepoCRUD _orders;
        private readonly IProductRepoStatistics _stats;
        private readonly IProductRepoCRUD _products;
        private readonly IUserRepoCRUD _users;

        public OrderCRUDController(IOrderRepoCRUD orders, IProductRepoStatistics stats, 
            IProductRepoCRUD products, IUserRepoCRUD users)
        {
            _orders = orders;
            _stats = stats;
            _products = products;
            _users = users;
        }

        [HttpPost("/orders/create")]
        public IActionResult CreateOrder(CreateOrderDto orderDto)
        {
            User User = _users.Read(orderDto.UserId);
            if(User == null)
            {
                return NotFound("Invalid user ID: " + orderDto.UserId);
            }

            Order Order = new Order();
            Order.UserId = orderDto.UserId;

            Order.PlacementTime = DateTime.Now;
            double ProductCost = 0;

            Order.Products = new List<OrderItems>();
            foreach(CreateOrderOrderItemsDto coi in orderDto.Products)
            {
                // Reading the necessary items
                Product product = _products.Read(coi.ProductId);

                // Exceptions
                if(product == null)
                {
                    return NotFound("Product with ID "+ coi.ProductId + " was not found.");
                }
                else if(product.AvailableQuantity < coi.Quantity)
                {
                    return BadRequest("Not enough quantity available for product ID "
                        + coi.ProductId + "(" + product.Name + "), " +
                        "Ordered: "+coi.Quantity +
                        ", Available: " + product.AvailableQuantity);
                }

                // Placement
                OrderItems oi = new OrderItems();
                oi.Product = product;
                oi.Quantity = coi.Quantity;
                Order.Products.Add(oi);

                // Extra
                ProductCost += product.Price * coi.Quantity;
            }

            Order.ProductsCost = ProductCost;
            Order.VoucherReduction = orderDto.VoucherReduction;
            Order.DeliveryCharge = orderDto.DeliveryCharge;
            Order.Total = Order.ProductsCost + Order.DeliveryCharge - Order.VoucherReduction;
            Order.DeliveryAddress = orderDto.DeliveryAddress;
            Order.CustomerPhoneNo = orderDto.CustomerPhoneNo;
            Order.DeliveryStatus = "Stage 1: Order placed";

            // Repository call
            bool added = _orders.Create(Order);
            if(added)
            {
                return Ok("Order placed.");
            }
            else
            {
                return BadRequest("Failed to place the order.");
            }
        }
    }
}
