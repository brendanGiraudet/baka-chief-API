using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.ProductInfoRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace bakaChiefApplication.API.Controllers;

public class ProductInfosController : ODataController
{
    private readonly IProductInfoRepository _productInfoRepository;

    public ProductInfosController(IProductInfoRepository productInfoRepository)
    {
        _productInfoRepository = productInfoRepository;
    }

    [EnableQuery]
    public async Task<ActionResult<IAsyncEnumerable<ProductInfo>>> GetAsync() => Ok(await _productInfoRepository.GetProductInfosAsync());

    [EnableQuery]
    public async Task<ActionResult<ProductInfo>> GetAsync([FromRoute] string key)
    {
        var product = await _productInfoRepository.GetProductInfoByIdAsync(key);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}