using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Repositories.RecipsRepository
{
    public interface IRecipsRepository
    {
        Task<IEnumerable<Recip>> GetRecipsAsync();
        Task<Recip> GetRecipByIdAsync(string id);
        Task AddRecipAsync(Recip recip);
        Task UpdateRecipAsync(Recip recip);
        Task DeleteRecipAsync(string id);
    }
}
