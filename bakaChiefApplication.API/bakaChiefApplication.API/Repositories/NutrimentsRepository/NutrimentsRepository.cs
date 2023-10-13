using bakaChiefApplication.API.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Repositories.NutrimentsRepository
{

    public class NutrimentsRepository : INutrimentsRepository
    {
        private readonly DatabaseContext _dbContext;

        public NutrimentsRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNutrimentAsync(Nutriment nutriment)
        {
            await _dbContext.Nutriments.AddAsync(nutriment);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Nutriment> GetNutrimentByIdAsync(string id)
        {
            return await _dbContext.Nutriments.FindAsync(id);
        }

        public async Task<IEnumerable<Nutriment>> GetNutrimentsAsync()
        {
            return _dbContext.Nutriments;
        }

        public async Task UpdateNutrimentAsync(Nutriment nutriment)
        {
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await DeleteNutrimentAsync(nutriment.Id);

                    await CreateNutrimentAsync(nutriment);

                    await dbContextTransaction.CommitAsync();

                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                }
            }

        }

        public async Task DeleteNutrimentAsync(string id)
        {
            var nutriment = await _dbContext.Nutriments.FindAsync(id);
            if (nutriment != null)
            {
                _dbContext.Nutriments.Remove(nutriment);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
