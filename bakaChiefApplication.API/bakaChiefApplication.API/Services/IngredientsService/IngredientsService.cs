using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.IngredientsRepository;
using bakaChiefApplication.API.Services.NutrimentsService;

namespace bakaChiefApplication.API.Services.IngredientsService
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientsRepository _ingredientRepository;
        private readonly INutrimentsService _nutrimentTypeService;

        public IngredientsService(IIngredientsRepository ingredientRepository, INutrimentsService nutrimentTypeService)
        {
            _ingredientRepository = ingredientRepository;
            _nutrimentTypeService = nutrimentTypeService;
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            List<Nutriment> nutriments = await GetExistingNutriments(ingredient.Nutriments);

            ingredient.Nutriments = nutriments;

            await _ingredientRepository.CreateIngredientAsync(ingredient);
        }

        private async Task<List<Nutriment>> GetExistingNutriments(ICollection<Nutriment> nutrimentTypes)
        {
            var existingNutrimentTypes = new List<Nutriment>();
            foreach (var nutrimentType in nutrimentTypes)
            {
                var existingNutrimentType = await _nutrimentTypeService.GetNutrimentByIdAsync(nutrimentType.Id);

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

        public async Task<List<Ingredient>> GetIngredientsAsync()
        {
            return await _ingredientRepository.GetIngredientsAsync();
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            List<Nutriment> nutriments = await GetExistingNutriments(ingredient.Nutriments);

            ingredient.Nutriments = nutriments;

            await _ingredientRepository.UpdateIngredientAsync(ingredient);
        }

        public async Task DeleteIngredientAsync(string id)
        {
            await _ingredientRepository.DeleteIngredientAsync(id);
        }
    }
}
