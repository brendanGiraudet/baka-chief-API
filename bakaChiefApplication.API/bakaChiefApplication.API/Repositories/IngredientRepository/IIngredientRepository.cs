using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Repositories.IngredientRepository
{
    public interface IIngredientRepository
    {
        Task CreateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(string id);
        Task<List<Ingredient>> GetAllIngredientsAsync();
        Task<Ingredient> GetIngredientByIdAsync(string id);
        Task UpdateIngredientAsync(Ingredient ingredient);
    }
}
