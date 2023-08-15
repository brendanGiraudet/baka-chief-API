using bakaChiefApplication.API.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Repositories.IngredientRepository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly DatabaseContext _dbContext;

        public IngredientRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            await _dbContext.Ingredients.AddAsync(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(string id)
        {
            return await _dbContext.Ingredients.Include(i => i.NutrimentTypes).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Ingredient>> GetAllIngredientsAsync()
        {
            return await _dbContext.Ingredients.Include(i => i.NutrimentTypes).ToListAsync();
        }

        public async Task UpdateIngredientAsync(Ingredient ingredient)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await DeleteIngredientAsync(ingredient.Id);

                    await CreateIngredientAsync(ingredient);

                    await dbContextTransaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                }
            }
        }

        public async Task DeleteIngredientAsync(string id)
        {
            var ingredient = await _dbContext.Ingredients.FindAsync(id);
            if (ingredient != null)
            {
                _dbContext.Ingredients.Remove(ingredient);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
