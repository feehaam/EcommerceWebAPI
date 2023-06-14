using EcommerceApplication.IRepository.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Models.Products;
using EcommerceApplication.DTO.Products;

namespace EcommerceApplication.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // necessary objects
        private readonly IProductRepoCRUD products;
        private readonly ICategoryCRUD category;
        private readonly ITagCRUD tags;

        // constructor 
        public ProductController(IProductRepoCRUD products, ICategoryCRUD cats, ITagCRUD tags)
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
            product.Tags = new List<Tag>();
            foreach(int tagId in productDto.TagIDs)
            {
                Tag tag = tags.Read(tagId);
                product.Tags.Add(tag); 
            }
            product.PhotosURL1 = productDto.PhotosURL1;
            product.PhotosURL2 = productDto.PhotosURL2;
            product.PhotosURL3 = productDto.PhotosURL3;
            product.AvailableQuantity = productDto.AvailableQuantity;
            product.Variants = new List<Variant>();
            foreach(VariantDto variantDto in productDto.Variants)
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
            ReadProductDto product = products.Read(productId);
            if(product == null || product.ProductId == -1)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut("/product/update")]
        public IActionResult UpdateProduct(Product product)
        {
            if(products.Update(product))
            {
                return Ok("Update successfull.");
            }
            return BadRequest("Failed to update product");
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
