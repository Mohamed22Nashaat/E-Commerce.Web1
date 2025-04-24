using Shared.DataTransferObjects.Products;

namespace ServicesAbstractions
{
    public interface IProductService
    {
        // Get All Products => IEnumerable<Product> 
        Task<PaginatedResponse<ProductResponse>> GetAllProductsAsync(ProductQueryParameters queryParameters);
        // Get product by id
        Task<ProductResponse> GetProductAsync(int id);
        // Get All Brands
        Task<IEnumerable<BrandResponse>> GetBrandsAsync();
        // Get All Types
        Task<IEnumerable<TypeResponse>> GetTypesAsync();
    }
}
