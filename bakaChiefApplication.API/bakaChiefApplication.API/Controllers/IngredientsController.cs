﻿using bakaChiefApplication.API.DatabaseModels;
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
        ingredient.IngredientNutriments = CleanIngredientNutriment(ingredient.IngredientNutriments);

        await _databaseContext.Ingredients.AddAsync(ingredient);

        await _databaseContext.SaveChangesAsync();

        return Created(ingredient);
    }

    private ICollection<IngredientNutriment> CleanIngredientNutriment(ICollection<IngredientNutriment> ingredients)
    {
        // Force to update and not create nutriments
            foreach (var ingred in ingredients)
            {
                ingred.Ingredient = null;
                ingred.Nutriment = null;
            }

        return ingredients;
    }

    public async Task<ActionResult> PutAsync([FromRoute] string key, [FromBody] Ingredient updatedIngredient)
    {
        if (updatedIngredient == null)
        {
            return NoContent();
        }

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
            RemoveMissingNutriments(updatedIngredient, ingredient);

            ingredient.IngredientNutriments = CleanIngredientNutriment(updatedIngredient.IngredientNutriments);

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

    private void RemoveMissingNutriments(Ingredient updatedIngredient, Ingredient? ingredient)
    {
        var nutrimentsToDelete = GetNutrimentsToDelete(ingredient, updatedIngredient.IngredientNutriments);

        if (nutrimentsToDelete.Count() != 0) _databaseContext.IngredientNutriments.RemoveRange(nutrimentsToDelete);
    }

    private IEnumerable<IngredientNutriment> GetNutrimentsToDelete(Ingredient currentIngredient, IEnumerable<IngredientNutriment> expectedNutriments)
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
