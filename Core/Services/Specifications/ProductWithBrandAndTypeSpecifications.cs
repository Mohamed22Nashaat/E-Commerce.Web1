using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public ProductWithBrandAndTypeSpecifications(int? brandId,int? typeId,ProductSortingOptions options)
            : base(CreateCriteria(brandId,typeId))
        {
            // Add Includes
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            ApplySorting(options);
        }

        private static System.Linq.Expressions.Expression<Func<Product, bool>> CreateCriteria(int? brandId, int? typeId)
        {
            return product =>
                (!brandId.HasValue || product.BrandId == brandId.Value) &&
                (!typeId.HasValue || product.TypeId == typeId.Value);
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
