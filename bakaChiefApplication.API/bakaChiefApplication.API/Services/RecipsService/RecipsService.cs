using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Repositories.RecipsRepository;
using bakaChiefApplication.API.Services.ProductInfoService;

namespace bakaChiefApplication.API.Services.RecipsService
{
    public class RecipsService : IRecipsService
    {
        private readonly IRecipsRepository _recipRepository;
        private readonly IProductInfoService _productInfoService;

        public RecipsService(IRecipsRepository recipRepository, IProductInfoService productInfoService)
        {
            _recipRepository = recipRepository ?? throw new ArgumentNullException(nameof(recipRepository));
            _productInfoService = productInfoService;
        }

        public async Task<IEnumerable<Recip>> GetRecipsAsync()
        {
            return await _recipRepository.GetRecipsAsync();
        }

        public async Task<Recip> GetRecipByIdAsync(string id)
        {
            return await _recipRepository.GetRecipByIdAsync(id);
        }

        public async Task CreateRecipAsync(Recip recip)
        {
            recip.RecipProductInfos = await GetExistingRecipIngredient(recip.RecipProductInfos);
            await _recipRepository.CreateRecipAsync(recip);
        }

        private async Task<List<RecipProductInfo>> GetExistingRecipIngredient(ICollection<RecipProductInfo> recipProductInfos)
        {
            var existingRecipIngredient = new List<RecipProductInfo>();
            foreach (var recipIngredient in recipProductInfos)
            {
                var existingIngredient = await _productInfoService.GetProductInfoByIdAsync(recipIngredient.ProductInfo.code);

                if (existingIngredient != null)
                {
                    recipIngredient.ProductInfo = existingIngredient;
                    existingRecipIngredient.Add(recipIngredient);
                }
            }

            return existingRecipIngredient;
        }

        public async Task UpdateRecipAsync(Recip recip)
        {
            recip.RecipProductInfos = await GetExistingRecipIngredient(recip.RecipProductInfos);

            await _recipRepository.UpdateRecipAsync(recip);
        }

        public async Task DeleteRecipAsync(string id)
        {
            await _recipRepository.DeleteRecipAsync(id);
        }
    }
}
