using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Services.ProductInfoService
{
    public interface IProductInfoService
    {
        Task CreateProductInfoAsync(ProductInfo productInfo);
        Task CreateProductInfosAsync(IEnumerable<ProductInfo> productInfos);
        Task<ProductInfo> GetProductInfoByIdAsync(string id);
        Task<IEnumerable<ProductInfo>> GetProductInfosAsync();
        Task UpdateProductInfoAsync(ProductInfo productInfoType);
        Task DeleteProductInfoAsync(string id);
    }
}
