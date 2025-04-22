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
        public ProductWithBrandAndTypeSpecifications(int? brandId,int? typeId)
            : base(product=>
            (!brandId.HasValue || product.BrandId == brandId.Value)&&
            (typeId.HasValue || product.TypeId == typeId.Value))
        {
            // Add Includes
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }


    }
}
