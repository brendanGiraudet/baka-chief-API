using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.ProductInfoRepository;

namespace bakaChiefApplication.API.Services.ProductInfoService
{
    public class ProductInfoService : IProductInfoService
    {
        private readonly IProductInfoRepository _productInfoRepository;

        public ProductInfoService(IProductInfoRepository productInfoRepository)
        {
            _productInfoRepository = productInfoRepository;
        }

        public async Task CreateProductInfoAsync(ProductInfo productInfo)
        {
            await _productInfoRepository.CreateProductInfoAsync(productInfo);
        }
        
        public async Task CreateProductInfosAsync(IEnumerable<ProductInfo> productInfos)
        {
            await _productInfoRepository.CreateProductInfosAsync(productInfos);
        }

        public async Task<ProductInfo> GetProductInfoByIdAsync(string id)
        {
            return await _productInfoRepository.GetProductInfoByIdAsync(id);
        }

        public async Task<IEnumerable<ProductInfo>> GetProductInfosAsync()
        {
            return await _productInfoRepository.GetProductInfosAsync();
        }

        public async Task UpdateProductInfoAsync(ProductInfo ProductInfoType)
        {
            await _productInfoRepository.UpdateProductInfoAsync(ProductInfoType);
        }

        public async Task DeleteProductInfoAsync(string id)
        {
            await _productInfoRepository.DeleteProductInfoAsync(id);
        }
    }
}