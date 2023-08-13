using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Services.NutrimentTypeService
{
    public interface INutrimentTypeService
    {
        Task CreateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task<NutrimentType> GetNutrimentTypeByIdAsync(string id);
        Task<List<NutrimentType>> GetAllNutrimentTypesAsync();
        Task UpdateNutrimentTypeAsync(NutrimentType nutrimentType);
        Task DeleteNutrimentTypeAsync(string id);
    }
}
