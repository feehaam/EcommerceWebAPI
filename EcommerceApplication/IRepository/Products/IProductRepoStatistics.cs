using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface IProductRepoStatistics
    {
        public Statistics ReadStatistics(int ProductId);
        public bool IncreaseFavorite(int ProductId);
        public bool DecreaseFavorite(int ProductId);
        public bool UpdateReviewScore(int ProductId, double Score);
    }
}
