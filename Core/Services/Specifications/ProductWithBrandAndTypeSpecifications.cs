

using Domain.Models.Products;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypeSpecifications
        : BaseSpecifications<Product>
    {

        //Use this CTOR to create Query to GEt Product by id
        public ProductWithBrandAndTypeSpecifications(int id) : base(product => product.Id ==id)
        {
            // Add Includes
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        // Use this CTOR to create Query to Get All Products
        // Use for filtration & sorting
        public ProductWithBrandAndTypeSpecifications(ProductQueryParameters parameters)
            : base(CreateCriteria(parameters))
        {
            // Add Includes
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            ApplySorting(parameters.options);
            ApplyPagination(parameters.PageSize, parameters.PageIndex);
        }

        private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
        {
            return product =>
                (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
                (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value) &&
                (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower()));
        }
            

        private void ApplySorting(ProductSortingOptions options)
        {
            switch (options)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }
        }
    }
}
