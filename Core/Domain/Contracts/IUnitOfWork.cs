

using Domain.Models;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        //IGenericRepository<Product,int> Products { get; set; }
        //IGenericRepository<ProductBrand, int> ProductBrands { get; set; }
        //IGenericRepository<ProductType, int> ProductTypes { get; set; }

        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>;
    }
}
