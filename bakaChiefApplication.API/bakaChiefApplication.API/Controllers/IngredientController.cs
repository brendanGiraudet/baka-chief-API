using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Services.IngredientService;
using Microsoft.AspNetCore.Mvc;

namespace bakaChiefApplication.API.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(Ingredient ingredient)
        {
            await _ingredientService.CreateIngredientAsync(ingredient);

            return StatusCode(StatusCodes.Status201Created, ingredient);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredientById(string id)
        {
            var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return Ok(ingredient);
        }

        [HttpGet]
        public async Task<ActionResult<List<Ingredient>>> GetAllIngredients()
        {
            var ingredients = await _ingredientService.GetAllIngredientsAsync();

            if (ingredients.Count == 0) return NoContent();

            return Ok(ingredients);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(string id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            await _ingredientService.UpdateIngredientAsync(ingredient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(string id)
        {
            await _ingredientService.DeleteIngredientAsync(id);
            return Ok();
        }
    }
}
