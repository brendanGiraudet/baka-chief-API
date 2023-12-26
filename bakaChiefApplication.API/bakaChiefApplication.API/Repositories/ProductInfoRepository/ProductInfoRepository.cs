using bakaChiefApplication.API.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Repositories.ProductInfoRepository;

public class ProductInfoRepository : IProductInfoRepository
{
    private readonly DatabaseContext _dbContext;

    private IAsyncEnumerable<ProductInfo> _products;

    public ProductInfoRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _products = dbContext.Products.AsAsyncEnumerable();
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

    public async Task<ProductInfo?> GetProductInfoByIdAsync(string id)
    {
        return  await _dbContext.Products.FirstOrDefaultAsync(p => p.code == id);
    }

    public async Task<IAsyncEnumerable<ProductInfo>> GetProductInfosAsync()
    {
        if(_products == null)
        {
            _products = _dbContext.Products.AsAsyncEnumerable();
        }
        
        return _products;
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