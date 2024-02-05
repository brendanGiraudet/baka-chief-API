using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Controllers;

public class MeasureUnitsController : ODataController
{
    private readonly DatabaseContext _databaseContext;

    public MeasureUnitsController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [EnableQuery]
    public ActionResult<IAsyncEnumerable<MeasureUnit>> Get() => Ok(_databaseContext.MeasureUnits);

    [EnableQuery]
    public async Task<ActionResult<MeasureUnit>> GetAsync([FromRoute] string key)
    {
        var measureUnit = await _databaseContext.MeasureUnits.FirstOrDefaultAsync(n => n.Id == key);

        if (measureUnit == null)
        {
            return NotFound();
        }

        return Ok(measureUnit);
    }

    public async Task<ActionResult> PostAsync([FromBody] MeasureUnit measureUnit)
    {
        await _databaseContext.MeasureUnits.AddAsync(measureUnit);

        await _databaseContext.SaveChangesAsync();

        return Created(measureUnit);
    }

    public async Task<ActionResult> PutAsync([FromRoute] string key, [FromBody] MeasureUnit updatedMeasureUnit)
    {
        if (updatedMeasureUnit == null)
        {
            return NoContent();
        }

        var measureUnit = await _databaseContext.MeasureUnits.FirstOrDefaultAsync(n => n.Id == key);

        if (measureUnit == null)
        {
            return NotFound();
        }

        measureUnit.Name = updatedMeasureUnit.Name;

        using var dbContextTransaction = _databaseContext.Database.BeginTransaction();

        try
        {
            await _databaseContext.SaveChangesAsync();

            await dbContextTransaction.CommitAsync();

            return Updated(measureUnit);
        }
        catch (System.Exception ex)
        {
            await dbContextTransaction.RollbackAsync();

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    public async Task<ActionResult> PatchAsync([FromRoute] string key, [FromBody] Delta<MeasureUnit> delta)
    {
        var measureUnit = await _databaseContext.MeasureUnits.FirstOrDefaultAsync(n => n.Id == key);

        if (measureUnit == null)
        {
            return NotFound();
        }

        delta.Patch(measureUnit);

        await _databaseContext.SaveChangesAsync();

        return Updated(measureUnit);
    }

    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var measureUnit = await _databaseContext.MeasureUnits.FirstOrDefaultAsync(n => n.Id == key);

        if (measureUnit == null)
        {
            return NotFound();
        }

        _databaseContext.MeasureUnits.Remove(measureUnit);

        await _databaseContext.SaveChangesAsync();

        return NoContent();
    }
}
