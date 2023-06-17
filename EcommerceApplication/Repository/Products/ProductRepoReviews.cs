using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Repository.Products
{
    public class ProductRepoReviews : IProductRepoReviews
    {
        private readonly DataContext context;
        public ProductRepoReviews(DataContext context)
        {
            this.context = context;
        }

        public bool AddReview(int ProductId, Review Review)
        {
            Product product = context.Products
                .Include(x => x.Statistics)
                    .ThenInclude(s => s.Reviews)
                .First(p => p.ProductId == ProductId);
            if(product == null)
            {
                return false;
            }
            if (product.Statistics == null)
            {
                return false;
            }
            if(product.Statistics.Reviews == null)
            {
                product.Statistics.Reviews = new List<Review>();
            }
            product.Statistics.Reviews.Add(Review);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteReview(int ReviewId)
        {
            try
            {
                Review review = Read(ReviewId);
                context.Reviews.Remove(review);
                return context.SaveChanges() > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public bool DownVote(int ReviewId)
        {
            try {
                Review review = context.Reviews.FirstOrDefault(r => r.ReviewId == ReviewId);
                if (review == null) return false;
                review.DownVote = review.DownVote + 1;
                return context.SaveChanges() > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public Review Read(int ReviewId)
        {
            Review review = context.Reviews.FirstOrDefault(r => r.ReviewId == ReviewId);
            if (review == null)
            {
                review = new Review();
                review.ReviewId = -1;
            }
            return review;
        }

        public ICollection<Review> ReadReviews(int ProductId)
        {
            try
            {
                return context.Products
                .Include(p => p.Statistics)
                    .ThenInclude(s => s.Reviews)
                .FirstOrDefault(p => p.ProductId == ProductId).Statistics.Reviews;
            }
            catch
            {
                return new List<Review>();
            }
        }

        public bool UpdateReview(Review Review)
        {
            try
            {
                context.Reviews.Update(Review);
                return context.SaveChanges() > 0 ? true : false;
            }
            catch { return false; }
        }

        public bool UpVote(int ReviewId)
        {
            try
            {
                Review review = context.Reviews.FirstOrDefault(r => r.ReviewId == ReviewId);
                if(review == null) return false;
                review.UpVote = review.UpVote + 1;
                return context.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
