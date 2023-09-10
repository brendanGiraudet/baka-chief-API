using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.RecipsRepository;
using bakaChiefApplication.API.Services.IngredientsService;

namespace bakaChiefApplication.API.Services.RecipsService
{
    public class RecipsService : IRecipsService
    {
        private readonly IRecipsRepository _recipRepository;
        private readonly IIngredientsService _ingredientService;

        public RecipsService(IRecipsRepository recipRepository, IIngredientsService ingredientService)
        {
            _recipRepository = recipRepository ?? throw new ArgumentNullException(nameof(recipRepository));
            _ingredientService = ingredientService;
        }

        public async Task<IEnumerable<Recip>> GetRecipsAsync()
        {
            return await _recipRepository.GetRecipsAsync();
        }

        public async Task<Recip> GetRecipByIdAsync(string id)
        {
            return await _recipRepository.GetRecipByIdAsync(id);
        }

        public async Task CreateRecipAsync(Recip recip)
        {
            recip.RecipIngredients = await GetExistingRecipIngredient(recip.RecipIngredients);
            await _recipRepository.CreateRecipAsync(recip);
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
            recip.RecipIngredients = await GetExistingRecipIngredient(recip.RecipIngredients);

            await _recipRepository.UpdateRecipAsync(recip);
        }

        public async Task DeleteRecipAsync(string id)
        {
            await _recipRepository.DeleteRecipAsync(id);
        }
    }
}
