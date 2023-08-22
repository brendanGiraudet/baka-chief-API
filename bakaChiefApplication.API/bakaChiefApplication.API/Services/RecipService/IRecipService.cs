using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Services.RecipService
{
    public interface IRecipService
    {
        Task<IEnumerable<Recip>> GetAllRecipsAsync();
        Task<Recip> GetRecipByIdAsync(string id);
        Task CreateRecipAsync(Recip recip);
        Task UpdateRecipAsync(Recip recip);
        Task DeleteRecipAsync(string id);
    }
}
