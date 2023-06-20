using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApplication.Repository.Products
{
    public class ProductRepoLists : IProductRepoLists
    {
        private readonly DataContext _context;

        public ProductRepoLists(DataContext dataContext)
        {
            _context = dataContext;
        }

        public ICollection<Product> GetAllProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Variants)
                .Include(p => p.Statistics)
                    .ThenInclude(s => s.Reviews)
                .ToList();
        }

        public ICollection<Product> GetProductsByCategory(string CategoryName)
        {
            return _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Name.ToLower().Equals(CategoryName.ToLower()))
                .Include(p => p.Tags)
                .Include(p => p.Variants)
                .Include(p => p.Statistics)
                    .ThenInclude(s => s.Reviews)
                .ToList(); 
        }

        public ICollection<Product> GetProductsByCategory(int CategoryId)
        {
            return _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.CategoryId == CategoryId)
                .Include(p => p.Tags)
                .Include(p => p.Variants)
                .Include(p => p.Statistics)
                    .ThenInclude(s => s.Reviews)
                .ToList();
        }

        public ICollection<Product> GetProductsByTag(string TagName)
        {
            ICollection<Product> allProducts = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Variants)
                .Include(p => p.Statistics)
                    .ThenInclude(s => s.Reviews)
                .ToList();

            ICollection<Product> result = new List<Product>();
            HashSet<int> resultProductIds = new HashSet<int>();

            foreach(Product p in allProducts)
            {
                if (p.Tags == null) continue;
                foreach(ProductTag tag in p.Tags)
                {
                    if(tag.Title.ToLower().Equals(TagName.ToLower()) && !resultProductIds.Contains(tag.ProductTagId))
                    {
                        resultProductIds.Add(tag.ProductTagId);
                        result.Add(p);
                    }
                }
            }

            return result;
        }

        public ICollection<Product> ProductFilter(int CategoryId, 
            string Tag1, string Tag2, string Tag3, string Tag4, string Tag5, 
            double PriceFrom, double PriceTo, int AvailableQuantity, string VariationTitle, 
            double MinReviewScore, double MaxReviewScore, int MinReviewCount, int MinSellCount, 
            int MinFavoriteCount, bool SortNewToOld, bool SortOldToNew, bool SortPriceHighToLow, 
            bool SortPriceLowToHigh, bool SortRatingHighToLow, bool SortRatingLowToHigh, 
            bool SortReviewsHighToLow, bool SortReviewsLowToHigh, int StartIndex, int NumberOfProducts)
        {
            IQueryable<Product> filter = _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.CategoryId == CategoryId)
                .Include(p => p.Tags)
                .Where(p => p.Price >= PriceFrom
                    && p.Price <= PriceTo
                    && p.AvailableQuantity >= AvailableQuantity)
                .Include(p => p.Statistics)
                .Where(p => p.Statistics.ReviewScore >= MinReviewScore
                    && p.Statistics.ReviewScore <= MaxReviewScore
                    && p.Statistics.Reviews.Count >= MinReviewCount
                    && p.Statistics.SellCount >= MinSellCount
                    && p.Statistics.Favorites >= MinFavoriteCount);

            filter = filter.Where(p => p.HasVariant(VariationTitle));
            filter = filter.Where(p => p.HasTag(Tag1) || p.HasTag(Tag2) || p.HasTag(Tag3) || p.HasTag(Tag4) || p.HasTag(Tag5));

            if (SortOldToNew) filter = filter.OrderBy(p => p.Created); 
            else if (SortPriceHighToLow) filter = filter.OrderByDescending(p => p.Price); 
            else if (SortPriceLowToHigh) filter = filter.OrderBy(p => p.Price); 
            else if (SortRatingHighToLow) filter = filter.OrderByDescending(p => p.Statistics.ReviewScore); 
            else if (SortRatingLowToHigh) filter = filter.OrderBy(p => p.Statistics.ReviewScore); 
            else if (SortReviewsHighToLow) filter = filter.OrderByDescending(p => p.Statistics.Reviews.Count); 
            else if (SortReviewsLowToHigh) filter = filter.OrderBy(p => p.Statistics.Reviews.Count);
            else filter = filter.OrderByDescending(p => p.Created);

            ICollection<Product> products = filter
                .Skip(StartIndex)
                .Take(NumberOfProducts)
                .ToList();

            return products;
        }
    }
}
