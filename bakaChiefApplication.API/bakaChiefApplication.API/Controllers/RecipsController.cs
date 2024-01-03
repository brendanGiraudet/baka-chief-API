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
        
        var existedSteps = GetExistingSteps(recip.RecipSteps);

        recip.RecipSteps = existedSteps;

        await _databaseContext.Recips.AddAsync(recip);

        await _databaseContext.SaveChangesAsync();

        return Created(recip);
    }

    private HashSet<RecipStep> GetExistingSteps(HashSet<RecipStep> recipSteps)
    {
         var ids = recipSteps.Select(n => n.Id);

        var existedSteps = _databaseContext.RecipSteps.Where(n => ids.Contains(n.Id));

        return existedSteps.ToHashSet();
    }

    private HashSet<Ingredient> GetExistingIngredients(HashSet<Ingredient> ingredients)
    {
        var ids = ingredients.Select(n => n.Id);

        var existedIngredients = _databaseContext.Ingredients.Where(n => ids.Contains(n.Id));

        return existedIngredients.ToHashSet();
    }

    public async Task<ActionResult> PutAsync([FromRoute] string key, [FromBody] Recip updatedRecip)
    {
        var recip = await _databaseContext.Recips.Include(i => i.Ingredients).Include(i => i.RecipSteps).FirstOrDefaultAsync(n => n.Id == key);

        if (recip == null)
        {
            return NotFound();
        }

        recip.Name = updatedRecip.Name;
        recip.ImageUrl = updatedRecip.ImageUrl;
        recip.PersonsNumber = updatedRecip.PersonsNumber;

        using var dbContextTransaction = _databaseContext.Database.BeginTransaction();

        try
        {
            var ingredientsToDelete = GetIngredientsToDelete(recip, updatedRecip.Ingredients);
            
            if(ingredientsToDelete.Count() != 0) _databaseContext.RecipIngredients.RemoveRange(ingredientsToDelete);

            var existedIngredients = GetExistingIngredients(updatedRecip.Ingredients);
            recip.Ingredients = existedIngredients;
            
            var stepsToDelete = GetStepsToDelete(recip, updatedRecip.RecipSteps);
            
            if(stepsToDelete.Count() != 0) _databaseContext.RecipSteps.RemoveRange(stepsToDelete);

            var existedSteps = GetExistingSteps(updatedRecip.RecipSteps);
            recip.RecipSteps = existedSteps;

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

    private IEnumerable<RecipStep> GetStepsToDelete(Recip currentRecip, HashSet<RecipStep> expectedRecipSteps)
    {
        var stepIdsToDelete = currentRecip.RecipSteps.Where(n => expectedRecipSteps.FirstOrDefault(e => e.Id == n.Id) == null).Select(n => n.Id);

        return _databaseContext.RecipSteps.Where(i => stepIdsToDelete.Contains(i.Id));
    }

    private IEnumerable<RecipIngredient> GetIngredientsToDelete(Recip currentRecip, HashSet<Ingredient> expectedIngredients)
    {
        var ingredientIdsToDelete = currentRecip.Ingredients.Where(n => expectedIngredients.FirstOrDefault(e => e.Id == n.Id) == null).Select(n => n.Id);

        return _databaseContext.RecipIngredients.Where(i => i.RecipId == currentRecip.Id && ingredientIdsToDelete.Contains(i.IngredientId));
    }

    public async Task<ActionResult> PatchAsync([FromRoute] string key, [FromBody] Delta<Recip> delta)
    {
        var recip = await _databaseContext.Recips.Include(i => i.Ingredients).FirstOrDefaultAsync(n => n.Id == key);

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
