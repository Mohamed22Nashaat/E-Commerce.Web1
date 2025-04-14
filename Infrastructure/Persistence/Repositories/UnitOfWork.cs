
namespace Persistence.Repositories
{
    public class UnitOfWork(StoreDbContext context) 
        : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public async Task<int> SaveChangesAsync() =>
           await context.SaveChangesAsync();
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var typeName = typeof(TEntity).Name;
            if (_repositories.ContainsKey(typeName))
            {
                return (IGenericRepository<TEntity, TKey>)_repositories[typeName];
            }

            var repo = new GenericRepository<TEntity, TKey>(context);
            _repositories[typeName] = repo;
            return repo;
        }
    }
}
//unitofwork.GetRepository<Product, int>();=> GenericRepository<Product, int>  

/// Request => Product Controller => Product Service [2 objetcs from Product Repo ]
/// Container for the Created Repos [Dictionary]
/// Dictionary<string, object> _repositories = [];
/// GetRepository=> Check if the required repo is already created => return without creating new object
/// if not => create new object and add it to the dictionary and return it
