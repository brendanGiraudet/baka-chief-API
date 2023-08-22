using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.RecipRepository;

namespace bakaChiefApplication.API.Services.RecipService
{
    public class RecipService : IRecipService
    {
        private readonly IRecipRepository _recipRepository;

        public RecipService(IRecipRepository recipRepository)
        {
            _recipRepository = recipRepository ?? throw new ArgumentNullException(nameof(recipRepository));
        }

        public async Task<IEnumerable<Recip>> GetAllRecipsAsync()
        {
            return await _recipRepository.GetAllRecipsAsync();
        }

        public async Task<Recip> GetRecipByIdAsync(string id)
        {
            return await _recipRepository.GetRecipByIdAsync(id);
        }

        public async Task CreateRecipAsync(Recip recip)
        {
            await _recipRepository.AddRecipAsync(recip);
        }

        public async Task UpdateRecipAsync(Recip recip)
        {
            await _recipRepository.UpdateRecipAsync(recip);
        }

        public async Task DeleteRecipAsync(string id)
        {
            await _recipRepository.DeleteRecipAsync(id);
        }
    }
}
