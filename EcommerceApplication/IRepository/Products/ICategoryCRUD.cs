using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface ICategoryCRUD
    {
        bool Create(int userId, Category category);
        Category Read(int categoryId);
        Category Read(string categoryName);
        bool Update(int userId, Category category);
        bool Delete(int userId, int categoryId);
        ICollection<Category> GetAll();
        ICollection<Tag> GetTags(int categoryId);
    }
}
