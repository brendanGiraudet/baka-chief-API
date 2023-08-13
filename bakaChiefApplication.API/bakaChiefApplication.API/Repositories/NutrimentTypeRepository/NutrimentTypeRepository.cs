using bakaChiefApplication.API.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace bakaChiefApplication.API.Repositories.NutrimentTypeRepository
{

    public class NutrimentTypeRepository : INutrimentTypeRepository
    {
        private readonly DatabaseContext _dbContext;

        public NutrimentTypeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNutrimentTypeAsync(NutrimentType nutrimentType)
        {
            await _dbContext.NutrimentTypes.AddAsync(nutrimentType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<NutrimentType> GetNutrimentTypeByIdAsync(string id)
        {
            return await _dbContext.NutrimentTypes.FindAsync(id);
        }

        public async Task<List<NutrimentType>> GetAllNutrimentTypesAsync()
        {
            return await _dbContext.NutrimentTypes.ToListAsync();
        }

        public async Task UpdateNutrimentTypeAsync(NutrimentType nutrimentType)
        {
            _dbContext.NutrimentTypes.Update(nutrimentType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNutrimentTypeAsync(string id)
        {
            var nutrimentType = await _dbContext.NutrimentTypes.FindAsync(id);
            if (nutrimentType != null)
            {
                _dbContext.NutrimentTypes.Remove(nutrimentType);
                await _dbContext.SaveChangesAsync();
            }
        }
    }


}
