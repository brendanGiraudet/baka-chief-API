using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Repositories.ProductInfoRepository;

public class ProductInfoRepository : IProductInfoRepository
{
    private readonly DatabaseContext _dbContext;

        public ProductInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateProductInfoAsync(ProductInfo productInfo)
        {
            await _dbContext.Products.AddAsync(productInfo);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task CreateProductInfosAsync(IEnumerable<ProductInfo> productInfos)
        {
            await _dbContext.Products.AddRangeAsync(productInfos);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductInfo> GetProductInfoByIdAsync(string id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<ProductInfo>> GetProductInfosAsync()
        {
            return _dbContext.Products;
        }

        public async Task UpdateProductInfoAsync(ProductInfo ProductInfo)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await DeleteProductInfoAsync(ProductInfo.code);

                    await CreateProductInfoAsync(ProductInfo);

                    await dbContextTransaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                }
            }

        }

        public async Task DeleteProductInfoAsync(string id)
        {
            var ProductInfo = await _dbContext.Products.FindAsync(id);
            if (ProductInfo != null)
            {
                _dbContext.Products.Remove(ProductInfo);
                await _dbContext.SaveChangesAsync();
            }
        }
}