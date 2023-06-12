using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface ITagCRUD 
    {
        public bool Create(int userId, Tag tag);
        public Tag Read(int tagId);
        public bool Update(int userId, Tag tag);
        public bool Delete(int userId, Tag tag);
        public ICollection<Tag> GetAll();
    }
}
