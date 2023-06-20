using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface IProductRepoReviews
    {
        // Review CRUD
        public Review Read(int ReviewId);
        public ICollection<Review> ReadReviews(int ProductId);
        public bool AddReview(int ProductId, Review Review);
        public bool UpdateReview(Review Review);
        public bool DeleteReview(int ReviewId);

        // Review Vote
        public bool UpVote(int ReviewId);
        public bool DownVote(int ReviewId);
    }
}
