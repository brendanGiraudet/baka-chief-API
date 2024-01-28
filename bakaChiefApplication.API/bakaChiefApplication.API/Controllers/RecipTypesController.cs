using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Controllers;

public class RecipTypesController : ODataController
{
    private readonly DatabaseContext _databaseContext;

    public RecipTypesController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [EnableQuery]
    public ActionResult<IAsyncEnumerable<RecipType>> Get() => Ok(_databaseContext.RecipTypes);

    [EnableQuery]
    public async Task<ActionResult<RecipType>> GetAsync([FromRoute] string key)
    {
        var recipType = await _databaseContext.RecipTypes.FirstOrDefaultAsync(n => n.Id == key);

        if (recipType == null)
        {
            return NotFound();
        }

        return Ok(recipType);
    }

    public async Task<ActionResult> PostAsync([FromBody] RecipType recipType)
    {
        await _databaseContext.RecipTypes.AddAsync(recipType);

        await _databaseContext.SaveChangesAsync();

        return Created(recipType);
    }

    public async Task<ActionResult> PutAsync([FromRoute] string key, [FromBody] RecipType updatedRecipType)
    {
        if (updatedRecipType == null)
        {
            return NoContent();
        }

        var recipType = await _databaseContext.RecipTypes.FirstOrDefaultAsync(n => n.Id == key);

        if (recipType == null)
        {
            return NotFound();
        }

        recipType.Name = updatedRecipType.Name;

        using var dbContextTransaction = _databaseContext.Database.BeginTransaction();

        try
        {
            await _databaseContext.SaveChangesAsync();

            await dbContextTransaction.CommitAsync();

            return Updated(recipType);
        }
        catch (System.Exception ex)
        {
            await dbContextTransaction.RollbackAsync();

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    public async Task<ActionResult> PatchAsync([FromRoute] string key, [FromBody] Delta<RecipType> delta)
    {
        var recipType = await _databaseContext.RecipTypes.FirstOrDefaultAsync(n => n.Id == key);

        if (recipType == null)
        {
            return NotFound();
        }

        delta.Patch(recipType);

        await _databaseContext.SaveChangesAsync();

        return Updated(recipType);
    }

    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var recipType = await _databaseContext.RecipTypes.FirstOrDefaultAsync(n => n.Id == key);

        if (recipType == null)
        {
            return NotFound();
        }

        _databaseContext.RecipTypes.Remove(recipType);

        await _databaseContext.SaveChangesAsync();

        return NoContent();
    }
}
