using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface IProductRepoStatistics
    {
        public Statistics ReadStatistics(int ProductId);
        public int IncreaseFavorite(int ProductId);
        public int DecreaseFavorite(int ProductId);
    }
}
