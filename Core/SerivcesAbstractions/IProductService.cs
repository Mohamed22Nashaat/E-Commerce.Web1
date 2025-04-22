
using Shared.DataTransferObjects;
using Shared.DataTransferObjects.Products;

namespace ServicesAbstractions
{
    public interface IProductService
    {
        // Get All Products => IEnumerable<Product> 
        Task<IEnumerable<ProductResponse>> GetAllProductsAsync(int? brandId, int? typeId,ProductSortingOptions options);
        // Get product by id
        Task<ProductResponse> GetProductAsync(int id);
        // Get All Brands
        Task<IEnumerable<BrandResponse>> GetBrandsAsync();
        // Get All Types
        Task<IEnumerable<TypeResponse>> GetTypesAsync();
    }
}
