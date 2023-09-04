using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Services.RecipsService
{
    public interface IRecipsService
    {
        Task<IEnumerable<Recip>> GetRecipsAsync();
        Task<Recip> GetRecipByIdAsync(string id);
        Task CreateRecipAsync(Recip recip);
        Task UpdateRecipAsync(Recip recip);
        Task DeleteRecipAsync(string id);
    }
}
