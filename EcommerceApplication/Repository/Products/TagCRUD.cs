using EcommerceApplication.DBContext;
using EcommerceApplication.IRepository.Products;
using EcommerceApplication.Models.Products;

namespace EcommerceApplication.Repository.Products
{
    public class TagCRUD : ITagCRUD
    {
        private readonly DataContext context;
        public TagCRUD(DataContext context)
        {
            this.context = context;
        }

        public bool Create(int userId, Tag tag)
        {
            context.Tags.Add(tag);
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
