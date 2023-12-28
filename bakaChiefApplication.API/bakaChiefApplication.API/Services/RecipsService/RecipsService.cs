using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.RecipsRepository;

namespace bakaChiefApplication.API.Services.RecipsService
{
    public class RecipsService : IRecipsService
    {
        private readonly IRecipsRepository _recipRepository;

        public RecipsService(IRecipsRepository recipRepository)
        {
            _recipRepository = recipRepository ?? throw new ArgumentNullException(nameof(recipRepository));
        }

        public async Task<IEnumerable<Recip>> GetRecipsAsync()
        {
            return await _recipRepository.GetRecipsAsync();
        }

        public async Task<Recip?> GetRecipByIdAsync(string id)
        {
            return await _recipRepository.GetRecipByIdAsync(id);
        }

        public async Task CreateRecipAsync(Recip recip)
        {
            await _recipRepository.CreateRecipAsync(recip);
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
