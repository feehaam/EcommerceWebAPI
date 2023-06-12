using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;

namespace EcommerceApplication.Repository.Products
{
    public class TagCRUD : ITagCRUD
    {
        private readonly DataContext context;
        private readonly ICategoryCRUD categoryCRUD;
        public TagCRUD(DataContext context, ICategoryCRUD categoryCRUD)
        {
            this.context = context;
            this.categoryCRUD = categoryCRUD;
        }

        public bool Create(int userId, int catId, Tag tag)
        {
            Category category = categoryCRUD.Read(catId);
            if(category == null)
            {
                return false;
            }
            if(category.Tags == null)
            {
                category.Tags = new List<Tag>();
            }
            category.Tags.Add(tag);
            return context.SaveChanges() > 0 ? true : false;
        }


        public Tag Read(int tagId)
        {
            var tag = context.Tags.FirstOrDefault(t => t.TagId == tagId);
            if(tag == null)
            {
                return new Tag
                {
                    TagId = -1,
                    Title = string.Empty
                };
            }
            return tag; 
        }

        public bool Update(int userId, Tag tag)
        {
            context.Tags.Update(tag);
            return context.SaveChanges() > 0 ? true : false;
        }
        public bool Delete(int userId, Tag tag)
        {
            context.Tags.Remove(tag);
            return context.SaveChanges() > 0 ? true : false;
        }
        public ICollection<Tag> GetAll()
        {
            return context.Tags.ToList();
        }
    }
}
