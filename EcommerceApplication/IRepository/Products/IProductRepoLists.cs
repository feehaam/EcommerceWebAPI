using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface IProductRepoLists
    {
        public ICollection<Product> GetAllProducts();
        public ICollection<Product> GetProductsByCategory(string CategoryName);
        public ICollection<Product> GetProductsByCategory(int CategoryId);
        public ICollection<Product> GetProductsByTag(string TagName);
        public ICollection<Product> ProductFilter
            (
                string CategoryId,
                string Tag1, string Tag2, string Tag3, string Tag4, string Tag5,
                string PriceFrom, 
                string PriceTo,
                string AvailableQuantity,
                string VariationTitle,
                double MinReviewScore,
                double MaxReviewScore,
                int MinReviewCount,
                int MinSellCount,
                int MinFavoriteCount,
                bool SortNewToOld,
                bool SortOldToNew,
                bool SortPriceHighToLow,
                bool SortPriceLowToHigh,
                bool SortRatingHighToLow,
                bool SortRatingLowToHigh,
                bool SortReviewsHighToLow,
                bool SortReviewsLowToHigh,
                int StartIndex,
                int NumberOfProducts
            );
    }
}