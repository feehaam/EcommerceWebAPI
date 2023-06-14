using EcommerceApplication.IRepository.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Models.Products;
using EcommerceApplication.DTO.Products;

namespace EcommerceApplication.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCRUDController : ControllerBase
    {
        // necessary objects
        private readonly IProductRepoCRUD products;
        private readonly ICategoryCRUD category;
        private readonly ITagCRUD tags;

        // constructor 
        public ProductCRUDController(IProductRepoCRUD products, ICategoryCRUD cats, ITagCRUD tags)
        {
            this.products = products;
            this.category = cats;
            this.tags = tags;
        }

        // create a new product
        [HttpPost("/product/create")]
        public IActionResult CreateProduct(CreateProductDto productDto)
        {
            Product product = new Product();
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Created = DateTime.Now;
            product.Category = category.Read(productDto.CategoryId);
            product.Tags = new List<ProductTag>();
            if(productDto.TagIDs != null)
            foreach(int tagId in productDto.TagIDs)
            {
                Tag tag = tags.Read(tagId);
                if(tag != null && tag.TagId != -1 && tag.Title != null)
                    {
                        ProductTag pt = new ProductTag();
                        pt.Title = tag.Title;
                        product.Tags.Add(pt);
                    }
            }
            product.PhotosURL1 = productDto.PhotosURL1;
            product.PhotosURL2 = productDto.PhotosURL2;
            product.PhotosURL3 = productDto.PhotosURL3;
            product.AvailableQuantity = productDto.AvailableQuantity;
            product.Variants = new List<Variant>();
            if (productDto.Variants != null)
            foreach (VariantDto variantDto in productDto.Variants)
            {
                product.Variants.Add(new Variant
                {
                    Title = variantDto.Title,
                    PhotoURL = variantDto.PhotoURL,
                    Price = variantDto.Price
                });
            }
            product.Statistics = new Statistics();
            if (products.Create(product))
            {
                return Ok("Successfully created.");
            }
            return BadRequest("Failed to create new product");
        }


        // get a product from product Id
        [HttpGet("/product/{productId}")]
        public IActionResult GetProduct(int productId)
        {
            Product product = products.Read(productId);
            ReadProductDto productDto = new ReadProductDto(product);

            if (product == null || product.ProductId == -1)
            {
                return NotFound();
            }

            return Ok(productDto);
        }

        [HttpPut("/product/update")]
        public IActionResult UpdateProduct(CreateProductDto productDto)
        {
            Product product = products.Read(productDto.ProductId);
            if(product == null) return NotFound();
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Category = category.Read(productDto.CategoryId);
            if (product.Tags != null)
            {
                product.Tags.Clear();
                
            }
            product.Tags = new List<ProductTag>();
            foreach(int tagId in productDto.TagIDs)
            {
                try
                {
                    Tag tag = tags.Read(tagId);
                    if (tag != null && tag.TagId != -1) {
                        ProductTag pt = new ProductTag();
                        pt.Title = tag.Title;
                        product.Tags.Add(pt);
                    }
                }
                catch { }
            }
            product.PhotosURL1 = productDto.PhotosURL1;
            product.PhotosURL2 = productDto.PhotosURL2;
            product.PhotosURL3 = productDto.PhotosURL3;
            product.AvailableQuantity = productDto.AvailableQuantity;

            if(products.Update(product)) return Ok("Update successfull.");
            return BadRequest("Failed to update");
        }

        [HttpDelete("/product/delete")]
        public IActionResult DeleteProduct(int productId)
        {
            if(products.Delete(productId))
            {
                return Ok("Succesfully deleted");
            }
            return BadRequest("Failed to delete the product");
        }
    }
}
