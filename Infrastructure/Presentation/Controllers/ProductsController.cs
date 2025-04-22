using Microsoft.AspNetCore.Mvc;
using ServicesAbstractions;
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Products;

namespace Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        // Get all products => IEnumerable<Product> .
        // Get product by id
        // Get All Brands
        // Get All Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetAllProducts(int? brandId, int? typeId, ProductSortingOptions sort) //Get BaseUrl/api/products
        {
            var products = await serviceManager.ProductService.GetAllProductsAsync(brandId,typeId,sort);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(int id)  //Get baseUrl/api/Products/{id}
        {
            var products = await serviceManager.ProductService.GetProductAsync(id);
            return Ok(products);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandResponse>>>GetBrands() //Get BaseUrl/api/products/brands
        {
            var products = await serviceManager.ProductService.GetBrandsAsync();
            return Ok(products);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeResponse>>> GetTypes() //Get BaseUrl/api/products/types
        {
            var products = await serviceManager.ProductService.GetTypesAsync();
            return Ok(products);
        }
    }
}
