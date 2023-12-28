using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Controllers;

public class RecipsController : ODataController
{
    private readonly DatabaseContext _databaseContext;

    public RecipsController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [EnableQuery]
    public ActionResult<IAsyncEnumerable<Recip>> Get() => Ok(_databaseContext.Recips);

    [EnableQuery]
    public async Task<ActionResult<Recip>> GetAsync([FromRoute] string key)
    {
        var recip = await _databaseContext.Recips.FirstOrDefaultAsync(n => n.Id == key);

        if (recip == null)
        {
            return NotFound();
        }

        return Ok(recip);
    }

    public async Task<ActionResult> PostAsync([FromBody] Recip recip)
    {
        var existedIngredients = GetExistingIngredients(recip.Ingredients);
        
        recip.Ingredients = existedIngredients;

        await _databaseContext.Recips.AddAsync(recip);

        await _databaseContext.SaveChangesAsync();

        return Created(recip);
    }

    private HashSet<Ingredient> GetExistingIngredients(HashSet<Ingredient> ingredients)
    {
        var ids = ingredients.Select(n => n.Id);

        var existedIngredients = _databaseContext.Ingredients.Where(n => ids.Contains(n.Id));

        return existedIngredients.ToHashSet();
    }

    public async Task<ActionResult> PutAsync([FromRoute] string key, [FromBody] Recip updatedRecip)
    {
        var recip = await _databaseContext.Recips.FirstOrDefaultAsync(n => n.Id == key);

        if (recip == null)
        {
            return NotFound();
        }

        recip.Name = updatedRecip.Name;
        recip.PersonsNumber = updatedRecip.PersonsNumber;
        recip.ImageUrl = updatedRecip.ImageUrl;

        var existedIngredients = GetExistingIngredients(updatedRecip.Ingredients);
        
        recip.Ingredients = existedIngredients;

        await _databaseContext.SaveChangesAsync();

        return Updated(recip);
    }

    public async Task<ActionResult> PatchAsync([FromRoute] string key, [FromBody] Delta<Recip> delta)
    {
        var recip = await _databaseContext.Recips.FirstOrDefaultAsync(n => n.Id == key);

        if (recip == null)
        {
            return NotFound();
        }

        delta.Patch(recip);

        await _databaseContext.SaveChangesAsync();

        return Updated(recip);
    }

    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var recip = await _databaseContext.Recips.FirstOrDefaultAsync(n => n.Id == key);

        if (recip == null)
        {
            return NotFound();
        }

        _databaseContext.Recips.Remove(recip);

        await _databaseContext.SaveChangesAsync();

        return NoContent();
    }
}
