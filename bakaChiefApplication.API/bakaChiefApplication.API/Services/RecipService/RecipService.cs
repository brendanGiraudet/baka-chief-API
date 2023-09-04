using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.RecipRepository;
using bakaChiefApplication.API.Services.IngredientsService;

namespace bakaChiefApplication.API.Services.RecipService
{
    public class RecipService : IRecipService
    {
        private readonly IRecipRepository _recipRepository;
        private readonly IIngredientsService _ingredientService;

        public RecipService(IRecipRepository recipRepository, IIngredientsService ingredientService)
        {
            _recipRepository = recipRepository ?? throw new ArgumentNullException(nameof(recipRepository));
            _ingredientService = ingredientService;
        }

        public async Task<IEnumerable<Recip>> GetAllRecipsAsync()
        {
            return await _recipRepository.GetAllRecipsAsync();
        }

        public async Task<Recip> GetRecipByIdAsync(string id)
        {
            return await _recipRepository.GetRecipByIdAsync(id);
        }

        public async Task CreateRecipAsync(Recip recip)
        {
            recip.RecipIngredients = await GetExistingRecipIngredient(recip.RecipIngredients);
            await _recipRepository.AddRecipAsync(recip);
        }

        private async Task<List<RecipIngredient>> GetExistingRecipIngredient(ICollection<RecipIngredient> recipIngredients)
        {
            var existingRecipIngredient = new List<RecipIngredient>();
            foreach (var recipIngredient in recipIngredients)
            {
                var existingIngredient = await _ingredientService.GetIngredientByIdAsync(recipIngredient.Ingredient.Id);

                if (existingIngredient != null)
                {
                    recipIngredient.Ingredient = existingIngredient;
                    existingRecipIngredient.Add(recipIngredient);
                }
            }

            return existingRecipIngredient;
        }

        public async Task UpdateRecipAsync(Recip recip)
        {
            await _recipRepository.UpdateRecipAsync(recip);
        }

        public async Task DeleteRecipAsync(string id)
        {
            await _recipRepository.DeleteRecipAsync(id);
        }
    }
}
