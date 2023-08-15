using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.IngredientRepository;

namespace bakaChiefApplication.API.Services.IngredientService
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            await _ingredientRepository.CreateIngredientAsync(ingredient);
        }

        public async Task<Ingredient> GetIngredientByIdAsync(string id)
        {
            return await _ingredientRepository.GetIngredientByIdAsync(id);
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _ingredientRepository.GetAllIngredientsAsync();
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            await _ingredientRepository.UpdateIngredientAsync(ingredient);
        }

        public async Task DeleteIngredientAsync(string id)
        {
            await _ingredientRepository.DeleteIngredientAsync(id);
        }
    }
}
