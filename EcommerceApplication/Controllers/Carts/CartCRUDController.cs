using EcommerceApplication.IRepository.Carts;
using EcommerceApplication.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Carts
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartCRUDController : ControllerBase
    {
        private readonly ICartRepoCRUD _cart;
        public CartCRUDController(ICartRepoCRUD cart)
        {
            _cart = cart;
        }
        [HttpPost("/cart/add")]
        public IActionResult AddItemToCart(int UserId, Product Product)
        {
            _cart.AddProduct(UserId, Product);
            return Ok("OK");
        }
    }
}
