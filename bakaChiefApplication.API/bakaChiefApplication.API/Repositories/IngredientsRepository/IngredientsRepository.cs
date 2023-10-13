﻿using bakaChiefApplication.API.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Repositories.IngredientsRepository
{
    public class IngredientsRepository : IIngredientsRepository
    {
        private readonly DatabaseContext _dbContext;

        public IngredientsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateIngredientAsync(Ingredient ingredient)
        {
            await _dbContext.Ingredients.AddAsync(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(string id)=> await _dbContext.Ingredients.Include(t => t.Nutriments).FirstOrDefaultAsync(i => i.Id == id);

        public async Task<IEnumerable<Ingredient>> GetIngredientsAsync() => _dbContext.Ingredients.Include(t => t.Nutriments);

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
            var ingredient = await GetIngredientByIdAsync(id);
            if (ingredient != null)
            {
                _dbContext.Ingredients.Remove(ingredient);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
