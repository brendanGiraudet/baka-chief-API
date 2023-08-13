using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.NutrimentTypeRepository;

namespace bakaChiefApplication.API.Services.NutrimentTypeService
{
    public class NutrimentTypeService : INutrimentTypeService
    {
        private readonly INutrimentTypeRepository _nutrimentTypeRepository;

        public NutrimentTypeService(INutrimentTypeRepository nutrimentTypeRepository)
        {
            _nutrimentTypeRepository = nutrimentTypeRepository;
        }

        public async Task CreateNutrimentTypeAsync(NutrimentType nutrimentType)
        {
            await _nutrimentTypeRepository.CreateNutrimentTypeAsync(nutrimentType);
        }

        public async Task<NutrimentType> GetNutrimentTypeByIdAsync(string id)
        {
            return await _nutrimentTypeRepository.GetNutrimentTypeByIdAsync(id);
        }

        public async Task<List<NutrimentType>> GetAllNutrimentTypesAsync()
        {
            return await _nutrimentTypeRepository.GetAllNutrimentTypesAsync();
        }

        public async Task UpdateNutrimentTypeAsync(NutrimentType nutrimentType)
        {
            await _nutrimentTypeRepository.UpdateNutrimentTypeAsync(nutrimentType);
        }

        public async Task DeleteNutrimentTypeAsync(string id)
        {
            await _nutrimentTypeRepository.DeleteNutrimentTypeAsync(id);
        }
    }
}
