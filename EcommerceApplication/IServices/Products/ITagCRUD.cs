using EcommerceApplication.Models.Products;

namespace EcommerceApplication.IRepository.Products
{
    public interface ITagCRUD 
    {
        public bool Create(int userId, int catId, Tag tag);
        public Tag Read(int tagId);
        public bool Update(int userId, Tag tag);
        public bool Delete(int userId, int tagId);
        public ICollection<Tag> GetAll();
    }
}
