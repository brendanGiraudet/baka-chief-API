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
        recip.RecipSteps = CleanRecipStep(recip.RecipSteps);

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

        var recip = await _databaseContext.Recips.Include(i => i.RecipIngredients).Include(i => i.RecipSteps).FirstOrDefaultAsync(n => n.Id == key);

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
            RemoveMissingIngredients(updatedRecip, recip);

            recip.RecipIngredients = CleanRecipIngredient(updatedRecip.RecipIngredients);

            RemoveMissingSteps(updatedRecip, recip);

            recip.RecipSteps = CleanRecipStep(updatedRecip.RecipSteps);
            
            recip.RecipSteps = AssociateAlreadyExistRecipStep(recip.RecipSteps);

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

    private ICollection<RecipStep> AssociateAlreadyExistRecipStep(ICollection<RecipStep> recipSteps)
    {
        var alreadyExistStep = GetExistingSteps(recipSteps);

        if (alreadyExistStep.Count() > 0)
        {
            foreach (var recipStep in alreadyExistStep)
            {
                var existedRecipStep = recipSteps.FirstOrDefault(r => r.Id == recipStep.Id);
                if (existedRecipStep != null)
                {
                    recipSteps.Remove(existedRecipStep);
                    recipSteps = recipSteps.Append(recipStep).ToHashSet();
                }
            }
        }

        return recipSteps;
    }

    private ICollection<RecipStep> GetExistingSteps(ICollection<RecipStep> recipSteps)
    {
        if (recipSteps is null) return recipSteps;

        var ids = recipSteps.Select(n => n.Id);

        var existedSteps = _databaseContext.RecipSteps.Where(n => ids.Contains(n.Id));

        return existedSteps.ToHashSet();
    }

    private ICollection<RecipIngredient> CleanRecipIngredient(ICollection<RecipIngredient> ingredients)
    {
        // Force to update and not create nutriments
        foreach (var ingred in ingredients)
        {
            ingred.Ingredient = null;
            ingred.Recip = null;
        }

        return ingredients;
    }

    private ICollection<RecipStep> CleanRecipStep(ICollection<RecipStep> steps)
    {
        // Force to update and not create nutriments
        foreach (var step in steps)
        {
            step.Recip = null;
        }

        return steps;
    }

    private void RemoveMissingIngredients(Recip updatedRecip, Recip? recip)
    {
        var ingredientsToDelete = GetIngredientsToDelete(recip, updatedRecip.RecipIngredients);

        if (ingredientsToDelete.Count() != 0) _databaseContext.RecipIngredients.RemoveRange(ingredientsToDelete);
    }

    private void RemoveMissingSteps(Recip updatedRecip, Recip? recip)
    {
        var stepsToDelete = GetStepsToDelete(recip, updatedRecip.RecipSteps);

        if (stepsToDelete.Count() != 0) _databaseContext.RecipSteps.RemoveRange(stepsToDelete);
    }

    private IEnumerable<RecipStep> GetStepsToDelete(Recip currentRecip, ICollection<RecipStep> expectedSteps)
    {
        var stepIdsToDelete = currentRecip.RecipSteps?.Where(n => n.Id == currentRecip.Id && !expectedSteps.Any(e => e.Id == n.Id)).Select(n => n.Id);

        return _databaseContext.RecipSteps.Where(i => i.Id == currentRecip.Id && stepIdsToDelete.Contains(i.Id));
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
