using EcommerceApplication.Models.Carts;
using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Carts
{
    public interface ICartRepoCRUD
    {
        public bool AddProduct(Product Product);
        public Cart ReadCart();
        public bool UpdateProduct(Product Product, int quantity);
        public bool DeleteProduct(Product Product);
    }
}
