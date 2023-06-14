using EcommerceApplication.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.DTO.Products
{
    public class VariantDto
    {
        public string Title { get; set; } = string.Empty;
        public string PhotoURL { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
