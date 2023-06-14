using EcommerceApplication.Models.Products;

namespace EcommerceApplication.DTO.Products
{
    public class ReadCategoryDto
    {
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public ReadCategoryDto(Category category)
        {
            CategoryId = category.CategoryId;
            Name = category.Name;
        }
    }
}
