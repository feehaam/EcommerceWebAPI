using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface IProductRepoCRUD
    {
        public bool Create(Product Product);
        public bool Read(int productId);
        public bool Update(Product Product);
        public bool Delete(int productId);
    }
}
