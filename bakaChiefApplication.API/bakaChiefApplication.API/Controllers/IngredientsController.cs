using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Controllers;

public class IngredientsController : ODataController
{
    private readonly DatabaseContext _databaseContext;

    public IngredientsController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    [EnableQuery]
    public ActionResult<IAsyncEnumerable<Ingredient>> Get() => Ok(_databaseContext.Ingredients);

    [EnableQuery]
    public async Task<ActionResult<Ingredient>> GetAsync([FromRoute] string key)
    {
        var ingredient = await _databaseContext.Ingredients.FirstOrDefaultAsync(n => n.Id == key);

        if (ingredient == null)
        {
            return NotFound();
        }

        return Ok(ingredient);
    }

    public async Task<ActionResult> PostAsync([FromBody] Ingredient ingredient)
    {
        await _databaseContext.Ingredients.AddAsync(ingredient);

        await _databaseContext.SaveChangesAsync();

        return Created(ingredient);
    }

    private HashSet<Nutriment> GetExistingNutriments(HashSet<Nutriment> nutriments)
    {
        var ids = nutriments.Select(n => n.Id);

        var existedNutriments = _databaseContext.Nutriments.Where(n => ids.Contains(n.Id));

        return existedNutriments.ToHashSet();
    }

    public async Task<ActionResult> PutAsync([FromRoute] string key, [FromBody] Ingredient updatedIngredient)
    {
        var ingredient = await _databaseContext.Ingredients.Include(i => i.IngredientNutriments).FirstOrDefaultAsync(n => n.Id == key);

        if (ingredient == null)
        {
            return NotFound();
        }

        ingredient.Name = updatedIngredient.Name;
        ingredient.ImageUrl = updatedIngredient.ImageUrl;
        ingredient.KcalNumber = updatedIngredient.KcalNumber;

        using var dbContextTransaction = _databaseContext.Database.BeginTransaction();

        try
        {
            var nutrimentsToDelete = GetNutrimentsToDelete(ingredient, updatedIngredient.IngredientNutriments);
            
            if(nutrimentsToDelete.Count() != 0) _databaseContext.IngredientNutriments.RemoveRange(nutrimentsToDelete);

            await _databaseContext.SaveChangesAsync();

            await dbContextTransaction.CommitAsync();

            return Updated(ingredient);
        }
        catch (System.Exception ex)
        {
            await dbContextTransaction.RollbackAsync();

            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    private IEnumerable<IngredientNutriment> GetNutrimentsToDelete(Ingredient currentIngredient, HashSet<IngredientNutriment> expectedNutriments)
    {
        var nutrimentIdsToDelete = currentIngredient.IngredientNutriments?.Where(n => n.IngredientId == currentIngredient.Id && !expectedNutriments.Any(a => a.NutrimentId == n.NutrimentId)).Select(n => n.NutrimentId) ?? Enumerable.Empty<string>();

        return _databaseContext.IngredientNutriments.Where(i => i.IngredientId == currentIngredient.Id && nutrimentIdsToDelete.Contains(i.NutrimentId));
    }

    public async Task<ActionResult> PatchAsync([FromRoute] string key, [FromBody] Delta<Ingredient> delta)
    {
        var ingredient = await _databaseContext.Ingredients.Include(i => i.IngredientNutriments).FirstOrDefaultAsync(n => n.Id == key);

        if (ingredient == null)
        {
            return NotFound();
        }

        delta.Patch(ingredient);

        await _databaseContext.SaveChangesAsync();

        return Updated(ingredient);
    }

    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var ingredient = await _databaseContext.Ingredients.FirstOrDefaultAsync(n => n.Id == key);

        if (ingredient == null)
        {
            return NotFound();
        }

        _databaseContext.Ingredients.Remove(ingredient);

        await _databaseContext.SaveChangesAsync();

        return NoContent();
    }
}
