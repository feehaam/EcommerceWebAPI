using EcommerceApplication.Models.Products;

namespace EcommerceApplication.DTO.Products
{
    public class ReadProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public DateTime Created { get; set; }
        public ReadCategoryDto ? Category { get; set; }
        public ICollection<string>? TagsS { get; set; }
        public string? PhotosURL1 { get; set; }
        public string? PhotosURL2 { get; set; }
        public string? PhotosURL3 { get; set; }
        public int AvailableQuantity { get; set; }
        public ICollection<Variant>? Variants { get; set; }
        public Statistics? Statistics { get; set; }
        public ReadProductDto(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Created = product.Created;
            Category = new ReadCategoryDto(product.Category);
            TagsS = new List<string>();
            foreach(Tag tag in product.Tags)
            {
                TagsS.Add(tag.Title);
            }
            PhotosURL1 = product.PhotosURL1;
            PhotosURL2 = product.PhotosURL2;
            PhotosURL3 = product.PhotosURL3;
            AvailableQuantity = product.AvailableQuantity;
            Variants = product.Variants;
            Statistics = product.Statistics;
        }
    }
}
