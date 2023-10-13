using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Repositories.IngredientsRepository
{
    public interface IIngredientsRepository
    {
        Task CreateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(string id);
        Task<IEnumerable<Ingredient>> GetIngredientsAsync();
        Task<Ingredient> GetIngredientByIdAsync(string id);
        Task UpdateIngredientAsync(Ingredient ingredient);
    }
}
