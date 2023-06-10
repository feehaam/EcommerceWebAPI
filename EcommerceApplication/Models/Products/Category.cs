namespace EcommerceApplication.Models.Products
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string ? Name { get; set; }
        public ICollection<Tag> ? Tags { get; set; }
    }
}
