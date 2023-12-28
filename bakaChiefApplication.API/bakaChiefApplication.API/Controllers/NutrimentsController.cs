using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Controllers;

public class NutrimentsController : ODataController
{
    private readonly DatabaseContext _databaseContext;

    public NutrimentsController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [EnableQuery]
    public ActionResult<IAsyncEnumerable<Nutriment>> Get() => Ok(_databaseContext.Nutriments);

    [EnableQuery]
    public async Task<ActionResult<Nutriment>> GetAsync([FromRoute] string key)
    {
        var nutriment = await _databaseContext.Nutriments.FirstOrDefaultAsync(n => n.Id == key);

        if (nutriment == null)
        {
            return NotFound();
        }

        return Ok(nutriment);
    }
}
