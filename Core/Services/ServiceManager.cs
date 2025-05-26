

namespace Services
{
    public class ServiceManager(IMapper mapper, IUnitOfWork unitOfWork, IBasketRepository basketRepository)
        : IServiceManager
    {
        private readonly Lazy<IProductService> _lazyproductService =
            new Lazy<IProductService>(()=>new ProductService(unitOfWork,mapper));
        public IProductService ProductService => _lazyproductService.Value;

        private readonly Lazy<IBasketService> _lazyBasketService =
            new Lazy<IBasketService>(() => new BasketService(basketRepository, mapper));
        public IBasketService BasketService => _lazyBasketService.Value;
    }
}
