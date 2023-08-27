using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.IngredientRepository;
using bakaChiefApplication.API.Services.NutrimentTypeService;

namespace bakaChiefApplication.API.Services.IngredientService
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly INutrimentTypeService _nutrimentTypeService;

        public IngredientService(IIngredientRepository ingredientRepository, INutrimentTypeService nutrimentTypeService)
        {
            _ingredientRepository = ingredientRepository;
            _nutrimentTypeService = nutrimentTypeService;
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            List<NutrimentType> nutrimentTypes = await GetExistingNutrimentTypes(ingredient.NutrimentTypes);

            ingredient.NutrimentTypes = nutrimentTypes;

            await _ingredientRepository.CreateIngredientAsync(ingredient);
        }

        private async Task<List<NutrimentType>> GetExistingNutrimentTypes(ICollection<NutrimentType> nutrimentTypes)
        {
            var existingNutrimentTypes = new List<NutrimentType>();
            foreach (var nutrimentType in nutrimentTypes)
            {
                var existingNutrimentType = await _nutrimentTypeService.GetNutrimentTypeByIdAsync(nutrimentType.Id);

                if (existingNutrimentType != null)
                {
                    existingNutrimentTypes.Add(existingNutrimentType);
                }
            }

            return existingNutrimentTypes;
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
