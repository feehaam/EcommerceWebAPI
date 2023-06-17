using EcommerceApplication.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.DTO.Products
{
    public class CreateReviewDto
    {
        public float Rating { get; set; }
        public string? Comment { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
