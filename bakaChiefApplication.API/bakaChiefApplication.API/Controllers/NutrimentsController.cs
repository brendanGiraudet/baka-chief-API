using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
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

    public async Task<ActionResult> PostAsync([FromBody] Nutriment nutriment)
    {
        await _databaseContext.Nutriments.AddAsync(nutriment);

        await _databaseContext.SaveChangesAsync();

        return Created(nutriment);
    }

    public async Task<ActionResult> PutAsync([FromRoute] string key, [FromBody] Nutriment updatedNutriment)
    {
        var nutriment = await _databaseContext.Nutriments.FirstOrDefaultAsync(n => n.Id == key);

        if (nutriment == null)
        {
            return NotFound();
        }

        nutriment.Name = updatedNutriment.Name;

        await _databaseContext.SaveChangesAsync();

        return Updated(nutriment);
    }

    public async Task<ActionResult> PatchAsync([FromRoute] string key, [FromBody] Delta<Nutriment> delta)
    {
        var nutriment = await _databaseContext.Nutriments.FirstOrDefaultAsync(n => n.Id == key);

        if (nutriment == null)
        {
            return NotFound();
        }

        delta.Patch(nutriment);

        await _databaseContext.SaveChangesAsync();

        return Updated(nutriment);
    }

    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var nutriment = await _databaseContext.Nutriments.FirstOrDefaultAsync(n => n.Id == key);

        if (nutriment == null)
        {
            return NotFound();
        }

        _databaseContext.Nutriments.Remove(nutriment);

        await _databaseContext.SaveChangesAsync();

        return NoContent();
    }
}
