using bakaChiefApplication.API.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Repositories.RecipsRepository
{
    public class RecipsRepository : IRecipsRepository
    {
        private readonly DatabaseContext _dbContext;

        public RecipsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Recip>> GetRecipsAsync()
        {
            return await Task.FromResult(_dbContext.Recips
                .Include(r => r.RecipIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                        .ThenInclude(i => i.Nutriments)
                .Include(r => r.RecipSteps));
        }

        public async Task<Recip> GetRecipByIdAsync(string id)
        {
            return await _dbContext.Recips
                .Include(r => r.RecipIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                        .ThenInclude(i => i.Nutriments)
                .Include(r => r.RecipSteps)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddRecipAsync(Recip recip)
        {
            await _dbContext.Recips.AddAsync(recip);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRecipAsync(Recip recip)
        {
            _dbContext.Recips.Update(recip);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRecipAsync(string id)
        {
            var recip = await _dbContext.Recips.FindAsync(id);
            if (recip != null)
            {
                _dbContext.Recips.Remove(recip);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
