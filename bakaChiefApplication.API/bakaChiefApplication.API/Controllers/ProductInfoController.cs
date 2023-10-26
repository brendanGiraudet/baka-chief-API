using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Services.ProductInfoService;
using Microsoft.AspNetCore.Mvc;

namespace bakaChiefApplication.API.Controllers
{
    [Route("api/productinfos")]
    [ApiController]
    public class ProductInfoController : ControllerBase
    {
        private readonly IProductInfoService _productInfoService;

        public ProductInfoController(IProductInfoService ProductInfoervice)
        {
            _productInfoService = ProductInfoervice ?? throw new ArgumentNullException(nameof(ProductInfoervice));
        }

        [HttpGet]
        public async Task<IActionResult> GetProductInfos()
        {
            var ProductInfo = await _productInfoService.GetProductInfosAsync();

           return StatusCode(StatusCodes.Status200OK, ProductInfo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductInfoById(string id)
        {
            var productInfo = await _productInfoService.GetProductInfoByIdAsync(id);
            if (productInfo == null)
            {
                return NotFound();
            }
            return Ok(productInfo);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductInfo(ProductInfo productInfo)
        {
            await _productInfoService.CreateProductInfoAsync(productInfo);
            return CreatedAtAction(nameof(GetProductInfoById), new { id = productInfo.code }, productInfo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductInfo(string id, ProductInfo ProductInfo)
        {
            if (id != ProductInfo.code)
            {
                return BadRequest();
            }

            await _productInfoService.UpdateProductInfoAsync(ProductInfo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductInfo(string id)
        {
            var ProductInfo = await _productInfoService.GetProductInfoByIdAsync(id);
            if (ProductInfo == null)
            {
                return NotFound();
            }

            await _productInfoService.DeleteProductInfoAsync(id);

            return NoContent();
        }
    }
}