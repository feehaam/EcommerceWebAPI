using EcommerceApplication.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApplication.DTO.Products
{ 
    public class CreateProductDto 
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public ICollection<int>? TagIDs { get; set; }
        public string? PhotosURL1 { get; set; }
        public string? PhotosURL2 { get; set; }
        public string? PhotosURL3 { get; set; }
        public int AvailableQuantity { get; set; }
        public ICollection<VariantDto>? Variants { get; set; }
    }
}


/*
{
  "name": "Xioami K50i 5G",
  "description": "The new budget killer predecessor to the legendary redmi K series from Xiomi the K50i is here to conquer the market with its hight performance processor and many other advanced features.",
  "price": 27500,
  "categoryId": 1002,
  "tagIDs": [
    3
  ],
  "photosURL1": "phonephotourl1",
  "photosURL2": "phonephotourl2",
  "photosURL3": "phonephotourl3",
  "variants": [
    {
      "title": "6/128 GB",
      "photoURL": "6gb pic",
      "price": 27500
    },
    {
      "title": "8/128 GB",
      "photoURL": "8gb pic",
      "price": 29000
    }
  ]
}
 */