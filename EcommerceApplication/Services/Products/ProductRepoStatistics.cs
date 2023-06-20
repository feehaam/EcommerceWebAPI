using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Repository.Products
{
    public class ProductRepoStatistics : IProductRepoStatistics
    {
        private readonly DataContext context;
        public ProductRepoStatistics(DataContext context)
        {
            this.context = context;
        }

        public int DecreaseFavorite(int ProductId)
        {
            try
            {
                Product product = context.Products
                    .Include(p => p.Statistics)
                    .FirstOrDefault(p => p.ProductId == ProductId);
                if(product != null && product.Statistics != null)
                {
                    product.Statistics.Favorites--;
                    if(product.Statistics.Favorites < 0)
                    {
                        product.Statistics.Favorites = 0;
                    }
                }
                return context.SaveChanges() > 0 ? product.Statistics.Favorites : -1;
            }
            catch
            {
                return -1;
            }
        }

        public int GetAvaiableQuantity(int ProductId)
        {
            Product Product = context.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (Product == null)
            {
                return -1;
            }
            else return Product.AvailableQuantity;
        }

        public int IncreaseFavorite(int ProductId)
        {
            try
            {
                Product product = context.Products
                    .Include(p => p.Statistics)
                    .FirstOrDefault(p => p.ProductId == ProductId);
                if (product != null && product.Statistics != null)
                {
                    product.Statistics.Favorites++;
                }
                return context.SaveChanges() > 0 ? product.Statistics.Favorites : -1;
            }
            catch
            {
                return -1;
            }
        }

        public Statistics ReadStatistics(int ProductId)
        {
            try
            {
                Statistics statistics = context.Statistics
                    .Include(s => s.Reviews)
                    .First(s => s.ProductId == ProductId);
                return statistics != null ? statistics : new Statistics()
                {
                    StatisticsId = -1
                };
            }
            catch
            {
                return new Statistics()
                {
                    StatisticsId = -1
                };
            }
            
        }
    }
}
