using EcommerceApplication.DTO.Products;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApplication.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IProductRepoReviews _reviews;

        public ReviewController(IProductRepoReviews reviews)
        {
            _reviews = reviews;
        }

        [HttpPost("/products/review/")]
        public IActionResult AddReview(CreateReviewDto reviewDto, int productId)
        {
            Review review = new Review();
            review.UpVote = 0;
            review.DownVote = 0;
            review.Comment = reviewDto.Comment;
            review.Rating = reviewDto.Rating;
            if(reviewDto.UserName == null || reviewDto.UserName.Length == 0)
            {
                reviewDto.UserName = "Anonymous";
            }
            review.UserName = reviewDto.UserName;
            bool status = _reviews.AddReview(productId, review);
            if (status)
            {
                return Ok("Review added.");
            }
            else return BadRequest("Failed to add review");
        }
        [HttpGet("/products/review/{ReviewId}")]
        public IActionResult GetReview(int ReviewId)
        {
            Review review = _reviews.Read(ReviewId);
            if(review.ReviewId == -1)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpDelete("/products/review/delete")]
        public IActionResult DeleteReview(int ReviewId)
        {
            if (_reviews.DeleteReview(ReviewId))
            {
                return Ok("Deleted. ");
            }
            else return NotFound();
        }
        [HttpPut("/products/review/upvote")]
        public IActionResult Upvote(int ReviewId)
        {
            if (_reviews.UpVote(ReviewId))
            {
                return Ok("Voted. ");
            }
            else return NotFound();
        }
        [HttpPut("/products/review/downvote")]
        public IActionResult Downvote(int ReviewId)
        {
            if (_reviews.DownVote(ReviewId))
            {
                return Ok("Voted. ");
            }
            else return NotFound();
        }
        [HttpPut("/products/reivew/update")]
        public IActionResult Update(CreateReviewDto reviewDto, int reviewId)
        {
            Review review = _reviews.Read(reviewId);
            if(review.ReviewId == -1) { return NotFound(); }
            review.Comment = reviewDto.Comment;
            review.Rating = reviewDto.Rating;
            if (reviewDto.UserName == null || reviewDto.UserName.Length == 0)
            {
                reviewDto.UserName = "Anonymous";
            }
            review.UserName = reviewDto.UserName;
            bool status = _reviews.UpdateReview(review);
            if (status)
            {
                return Ok("Review updated.");
            }
            else return BadRequest("Failed to update review");
        }
        [HttpGet("/products/reivews/{productId}")]
        public IActionResult ReviewsOfProduct(int productId)
        {
            return Ok(_reviews.ReadReviews(productId));
        }
    }
}
