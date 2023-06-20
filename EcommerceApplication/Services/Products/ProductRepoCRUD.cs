using EcommerceApplication.DBContext;
using EcommerceApplication.DTO.Products;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                DeleteTags(productId);
                context.Remove(Read(productId));
                return context.SaveChanges() > 0 ? true : false;
            }
            catch { 
                return false;
            }
        }

        public Product Read(int productId)
        {
            Product product = context.Products
                .Include(p => p.Category)
                .Include(p => p.Tags)
                .Include(p => p.Variants)
                .Include(p => p.Statistics)
                    .ThenInclude(s => s.Reviews)
                .FirstOrDefault(p => p.ProductId == productId);

            
            return product;
        }

        public bool Update(Product Product)
        {
            try
            {
                DeleteTags(Product.ProductId);
                context.Products.Update(Product);
                return context.SaveChanges() > 0 ? true : false;
            }
            catch 
            {
                return false;
            }
        }
        public void DeleteTags(int productId)
        {
            List<ProductTag> tags = context.ProductTags.Where(pt => pt.ProductId == null || pt.ProductId == productId).ToList();
            foreach (ProductTag tag in tags)
            {
                context.ProductTags.Remove(tag);
            }
            context.SaveChanges();
        }

        void IProductRepoCRUD.DeleteTags(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
