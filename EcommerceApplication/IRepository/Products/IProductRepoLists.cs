using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface IProductRepoLists
    {
        public ICollection<Product> GetAllProducts();

    }
}
