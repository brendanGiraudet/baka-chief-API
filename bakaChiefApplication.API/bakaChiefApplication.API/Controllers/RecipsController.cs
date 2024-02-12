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
        recip.RecipIngredients = CleanRecipIngredient(recip.RecipIngredients);

        await _databaseContext.Recips.AddAsync(recip);

        await _databaseContext.SaveChangesAsync();

        return Created(recip);
    }

    public async Task<ActionResult> PutAsync([FromRoute] string key, [FromBody] Recip updatedRecip)
    {
        if (updatedRecip == null)
        {
            return NoContent();
        }

        var recip = await _databaseContext.Recips.Include(i => i.RecipIngredients).FirstOrDefaultAsync(n => n.Id == key);

        if (recip == null)
        {
            return NotFound();
        }

        recip.Name = updatedRecip.Name;
        recip.ImageUrl = updatedRecip.ImageUrl;
        recip.PersonsNumber = updatedRecip.PersonsNumber;
        recip.Preparation = updatedRecip.Preparation;
        recip.RecipTypeId = updatedRecip.RecipTypeId;

        using var dbContextTransaction = _databaseContext.Database.BeginTransaction();

        try
        {
            RemoveMissingIngredients(updatedRecip, recip);

            recip.RecipIngredients = CleanRecipIngredient(updatedRecip.RecipIngredients);

            await _databaseContext.SaveChangesAsync();

            await dbContextTransaction.CommitAsync();

            return Updated(recip);
        }
        catch (System.Exception ex)
        {
            await dbContextTransaction.RollbackAsync();

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    private ICollection<RecipIngredient> CleanRecipIngredient(ICollection<RecipIngredient> ingredients)
    {
        // Force to update and not create nutriments
        foreach (var ingred in ingredients)
        {
            ingred.Ingredient = null;
            ingred.Recip = null;
            ingred.MeasureUnit = null;
        }

        return ingredients;
    }

    private void RemoveMissingIngredients(Recip updatedRecip, Recip? recip)
    {
        var ingredientsToDelete = GetIngredientsToDelete(recip, updatedRecip.RecipIngredients);

        if (ingredientsToDelete.Count() != 0) _databaseContext.RecipIngredients.RemoveRange(ingredientsToDelete);
    }

    private IEnumerable<RecipIngredient> GetIngredientsToDelete(Recip currentRecip, ICollection<RecipIngredient> expectedIngredients)
    {
        var ingredientIdsToDelete = currentRecip.RecipIngredients?.Where(n => n.RecipId == currentRecip.Id && !expectedIngredients.Any(e => e.IngredientId == n.IngredientId)).Select(n => n.IngredientId);

        return _databaseContext.RecipIngredients.Where(i => i.RecipId == currentRecip.Id && ingredientIdsToDelete.Contains(i.IngredientId));
    }


    public async Task<ActionResult> PatchAsync([FromRoute] string key, [FromBody] Delta<Recip> delta)
    {
        var recip = await _databaseContext.Recips.Include(i => i.RecipIngredients).FirstOrDefaultAsync(n => n.Id == key);

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
