using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Services.ProductInfoService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace bakaChiefApplication.API.Controllers;

public class ProductInfoLightsController : ODataController
{
    private readonly IProductInfoService _productInfoService;

    public ProductInfoLightsController(IProductInfoService productInfoService)
    {
        _productInfoService = productInfoService;
    }

    [EnableQuery]
    public async Task<ActionResult<IEnumerable<ProductInfoLight>>> GetAsync()
    {
        var products = await _productInfoService.GetProductInfosAsync();

        return Ok(products);
    }

    [EnableQuery]
    public async Task<ActionResult<ProductInfoLight>> GetAsync([FromRoute] int key)
    {
        var product = await _productInfoService.GetProductInfoByIdAsync(key.ToString());

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}