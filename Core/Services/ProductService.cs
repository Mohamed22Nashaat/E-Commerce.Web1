


using Domain.Exceptions;
using Services.Specifications;

namespace Services
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) 
        : IProductService
    {
        public async Task<PaginatedResponse<ProductResponse>> GetAllProductsAsync(ProductQueryParameters queryParameters)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(queryParameters);
            var product = await unitOfWork.GetRepository<Product, int>().GetAllAsync(specifications);
            var data = mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(product);
            var pageCount = data.Count();
            var totalCount = await unitOfWork.GetRepository<Product, int>().CountAsync(new ProductCountSpecifications(queryParameters));
            return new(queryParameters.PageIndex,pageCount, totalCount, data);
        }

        
        public async Task<ProductResponse> GetProductAsync(int id)
        {
            var specifications = new ProductWithBrandAndTypeSpecifications(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(specifications) ??
                throw new ProductNotFoundException(id);
            return mapper.Map<Product, ProductResponse>(product);
        }

        public async Task<IEnumerable<BrandResponse>> GetBrandsAsync()
        {
            //Unit of work => IEnumerable<ProductTypes>
            var repo = unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repo.GetAllAsync();
            // Automapper => IEnumerable<ProductTypes> => IEnumerable<TypeResponse>
            return mapper.Map<IEnumerable<ProductBrand>, IEnumerable<BrandResponse>>(brands);
        }

        public async Task<IEnumerable<TypeResponse>> GetTypesAsync()
        {
            //Unit of work => IEnumerable<ProductTypes>
            var repo =  unitOfWork.GetRepository<ProductType, int>();
            var types = await repo.GetAllAsync();
            // Automapper => IEnumerable<ProductTypes> => IEnumerable<TypeResponse>
            return mapper.Map<IEnumerable<ProductType>,IEnumerable<TypeResponse>>(types);
            
        }
    }
}
