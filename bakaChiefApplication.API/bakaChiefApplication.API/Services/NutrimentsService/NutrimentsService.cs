using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.NutrimentsRepository;

namespace bakaChiefApplication.API.Services.NutrimentsService
{
    public class NutrimentsService : INutrimentsService
    {
        private readonly INutrimentsRepository _nutrimentsRepository;

        public NutrimentsService(INutrimentsRepository nutrimentTypeRepository)
        {
            _nutrimentsRepository = nutrimentTypeRepository;
        }

        public async Task CreateNutrimentAsync(Nutriment nutrimentType)
        {
            await _nutrimentsRepository.CreateNutrimentAsync(nutrimentType);
        }

        public async Task<Nutriment> GetNutrimentByIdAsync(string id)
        {
            return await _nutrimentsRepository.GetNutrimentByIdAsync(id);
        }

        public async Task<IEnumerable<Nutriment>> GetNutrimentsAsync()
        {
            return await _nutrimentsRepository.GetNutrimentsAsync();
        }

        public async Task UpdateNutrimentAsync(Nutriment nutrimentType)
        {
            await _nutrimentsRepository.UpdateNutrimentAsync(nutrimentType);
        }

        public async Task DeleteNutrimentAsync(string id)
        {
            await _nutrimentsRepository.DeleteNutrimentAsync(id);
        }
    }
}
