using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Repositories.NutrimentTypeRepository
{
    public interface INutrimentTypeRepository
    {
        Task CreateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task<NutrimentType> GetNutrimentTypeByIdAsync(string id);
        Task<List<NutrimentType>> GetAllNutrimentTypesAsync();
        Task UpdateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task DeleteNutrimentTypeAsync(string id);
    }
}
