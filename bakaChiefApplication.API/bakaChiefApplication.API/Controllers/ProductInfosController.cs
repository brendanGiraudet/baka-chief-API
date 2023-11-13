using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace bakaChiefApplication.API.Controllers;

public class ProductInfosController : ODataController
{
    private readonly DatabaseContext _databaseContext;

    public ProductInfosController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [EnableQuery]
    public async Task<ActionResult<IQueryable<ProductInfo>>> GetAsync() => Ok(_databaseContext.Products);

    [EnableQuery]
    public async Task<ActionResult<ProductInfo>> GetAsync([FromRoute] string key)
    {
        var product = _databaseContext.Products.FirstOrDefault(p => p.code == key);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
}