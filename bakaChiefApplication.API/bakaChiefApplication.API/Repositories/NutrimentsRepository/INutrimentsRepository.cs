using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Repositories.NutrimentsRepository
{
    public interface INutrimentsRepository
    {
        Task CreateNutrimentAsync(Nutriment nutrimentType);
        Task<Nutriment> GetNutrimentByIdAsync(string id);
        Task<List<Nutriment>> GetNutrimentsAsync();
        Task UpdateNutrimentAsync(Nutriment nutrimentType);
        Task DeleteNutrimentAsync(string id);
    }
}
