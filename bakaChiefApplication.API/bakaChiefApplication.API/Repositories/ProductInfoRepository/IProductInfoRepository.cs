using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Repositories.ProductInfoRepository;

public interface IProductInfoRepository
{
    Task CreateProductInfoAsync(ProductInfo productInfo);
    Task CreateProductInfosAsync(IEnumerable<ProductInfo> productInfos);
    Task<ProductInfo> GetProductInfoByIdAsync(string id);
    Task<IAsyncEnumerable<ProductInfo>> GetProductInfosAsync();
    Task UpdateProductInfoAsync(ProductInfo productInfoType);
    Task DeleteProductInfoAsync(string id);
}