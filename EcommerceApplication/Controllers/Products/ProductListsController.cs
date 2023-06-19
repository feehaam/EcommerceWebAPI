using EcommerceApplication.IRepository.Products;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListsController : ControllerBase
    {
        private readonly IProductRepoLists _lists;
        public ProductListsController(IProductRepoLists lists)
        {
            _lists = lists;
        }

        [HttpGet("/products")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_lists.GetAllProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/products/category/{id:int}")]
        public IActionResult GetByCatId(int id)
        {
            try
            {
                return Ok(_lists.GetProductsByCategory(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/products/category/{name}")]
        public IActionResult GetByCatName(string name)
        {
            try
            {
                return Ok(_lists.GetProductsByCategory(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/products/tag/{tagName}")]
        public IActionResult GetByTag(string tagName)
        {
            try
            {
                return Ok(_lists.GetProductsByTag(tagName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/products/filter")]
        public IActionResult Filter(int CategoryId,
        string Tag1, string Tag2, string Tag3, string Tag4, string Tag5,
        double PriceFrom, double PriceTo, int AvailableQuantity, string VariationTitle,
        double MinReviewScore, double MaxReviewScore, int MinReviewCount, int MinSellCount,
        int MinFavoriteCount, bool SortNewToOld, bool SortOldToNew, bool SortPriceHighToLow,
        bool SortPriceLowToHigh, bool SortRatingHighToLow, bool SortRatingLowToHigh,
        bool SortReviewsHighToLow, bool SortReviewsLowToHigh, int StartIndex, int NumberOfProducts)
        {
            try
            {
                return Ok(_lists.ProductFilter(CategoryId, Tag1, Tag2, Tag3, Tag4, Tag5,
                PriceFrom, PriceTo, AvailableQuantity, VariationTitle,
                MinReviewScore, MaxReviewScore, MinReviewCount, MinSellCount,
                MinFavoriteCount, SortNewToOld, SortOldToNew, SortPriceHighToLow,
                SortPriceLowToHigh, SortRatingHighToLow, SortRatingLowToHigh,
                SortReviewsHighToLow, SortReviewsLowToHigh, StartIndex, NumberOfProducts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
