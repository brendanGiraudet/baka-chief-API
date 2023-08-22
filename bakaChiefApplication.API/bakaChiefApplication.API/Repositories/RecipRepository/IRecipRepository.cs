using bakaChiefApplication.API.DatabaseModels;

namespace bakaChiefApplication.API.Repositories.RecipRepository
{
    public interface IRecipRepository
    {
        Task<IEnumerable<Recip>> GetAllRecipsAsync();
        Task<Recip> GetRecipByIdAsync(string id);
        Task AddRecipAsync(Recip recip);
        Task UpdateRecipAsync(Recip recip);
        Task DeleteRecipAsync(string id);
    }
}
