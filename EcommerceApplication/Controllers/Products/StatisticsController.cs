using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IProductRepoStatistics stats;
        public StatisticsController(IProductRepoStatistics stats)
        {
            this.stats = stats;
        }
        [HttpGet("/statistics/{productId}")]
        public IActionResult Get(int productId)
        {
            Statistics statistics = stats.ReadStatistics(productId);
            if (statistics == null || statistics.StatisticsId == -1)
            {
                return NotFound();
            }
            else return Ok(statistics);
        }
        [HttpPost("/statistics/increaseFav/{productId}")]
        public IActionResult Inc(int productId)
        {
            int fav = stats.IncreaseFavorite(productId);
            if (fav == -1)
            {
                return NotFound();
            }
            else return Ok("Done. New favorite count: "+fav);
        }
        [HttpDelete("/statistics/decreaseFav/{productId}")]
        public IActionResult Dec(int productId)
        {
            int fav = stats.DecreaseFavorite(productId);
            if (fav == -1)
            {
                return NotFound();
            }
            else return Ok("Done. New favorite count: " + fav);
        }
    }
}
