using EcommerceApplication.IRepository.Carts;
using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Carts
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartCRUD : ControllerBase
    {
        private readonly ICartRepoCRUD _carts;
        public CartCRUD(ICartRepoCRUD carts)
        {
            _carts = carts;
        }

        [HttpPost("/cart/add")]
        public IActionResult AddToCart(int UserId, int ProductId, int Quantity)
        {
            bool done = _carts.AddProduct(UserId, ProductId, Quantity);
            if (done)
            {
                return Ok("Added to the cart");
            }
            else
            {
                return BadRequest("Failed add to the cart");
            }
        }
        [HttpGet("/cart/{UserId}")]
        public IActionResult ReadCart(int UserId)
        {
            Cart cart = _carts.ReadCart(UserId);
            if(cart == null)
            {
                return BadRequest("Cart doesn't exist");
            }
            return Ok(cart);
        }

        [HttpPut("/cart/update")]
        public IActionResult UpdateCart(int UserId, int productId, int Quantity)
        {
            if (_carts.UpdateProduct(UserId, productId, Quantity))
            {
                return Ok("Updated.");
            }
            else return BadRequest("Failed to update the item into cart.");
        }

        [HttpDelete("/cart/delete")]
        public IActionResult DeleteItem(int UserId, int ProductId)
        {
            if (_carts.DeleteProduct(UserId, ProductId))
            {
                return Ok("Deleted.");
            }
            else return BadRequest("Failed to delete the item into cart.");
        }
    }
}
