using bakaChiefApplication.API.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Repositories.RecipRepository
{
    public class RecipRepository : IRecipRepository
    {
        private readonly DatabaseContext _dbContext;

        public RecipRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Recip>> GetAllRecipsAsync()
        {
            return await _dbContext.Recips.ToListAsync();
        }

        public async Task<Recip> GetRecipByIdAsync(string id)
        {
            return await _dbContext.Recips.FindAsync(id);
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
