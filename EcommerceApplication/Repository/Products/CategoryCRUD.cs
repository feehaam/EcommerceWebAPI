using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;

namespace EcommerceApplication.Repository.Products
{
    public class CategoryCRUD : ICategoryCRUD
    {
        private readonly DataContext context;
        public CategoryCRUD(DataContext context) { 
            this.context = context;
        }

        public bool Create(int userId, Category category)
        {
            context.Categories.Add(category);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(int userId, int categoryId)
        {
            Category category = Read(categoryId);
            context.Categories.Remove(category);
            return context.SaveChanges() > 0 ? true : false;
        }

        public ICollection<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category Read(int categoryId)
        {
            return context.Categories.FirstOrDefault(cat => cat.CategoryId == categoryId);
        }

        public Category Read(string categoryName)
        {
            return context.Categories.FirstOrDefault(cat => cat.Name == categoryName);
        }

        public bool Update(int userId, Category category)
        {
            context.Categories.Update(category);
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
