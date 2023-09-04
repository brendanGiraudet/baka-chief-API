using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Services.NutrimentsService
{
    public interface INutrimentsService
    {
        Task CreateNutrimentAsync(Nutriment nutriment);
        Task<Nutriment> GetNutrimentByIdAsync(string id);
        Task<List<Nutriment>> GetNutrimentsAsync();
        Task UpdateNutrimentAsync(Nutriment nutriment);
        Task DeleteNutrimentAsync(string id);
    }
}
