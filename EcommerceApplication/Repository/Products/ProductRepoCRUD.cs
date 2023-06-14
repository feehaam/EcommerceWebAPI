using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;

namespace EcommerceApplication.Repository.Products
{
    public class ProductRepoCRUD : IProductRepoCRUD
    {
        private readonly DataContext context;
        public ProductRepoCRUD(DataContext context)
        {
            this.context = context;
        }

        public bool Create(Product Product)
        {
            context.Products.Add(Product);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int productId)
        {
            context.Remove(Read(productId));
            return context.SaveChanges() > 0 ? true : false;
        }

        public Product Read(int productId)
        {
            Product product = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if(product == null)
            {
                return new Product()
                {
                    ProductId = -1
                };
            }
            return product;
        }

        public bool Update(Product Product)
        {
            try
            {
                context.Products.Update(Product);
                return context.SaveChanges() > 0 ? true : false;
            }
            catch 
            {
                return false;
            }
        }
    }
}
