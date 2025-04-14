
using AutoMapper;
using Domain.Contracts;
using Domain.Models;

namespace Services
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) 
        : IProductService
    {
        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAllAsync();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductResponse>>(product);
        }

        
        public async Task<ProductResponse> GetProductAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetAsync(id);
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
