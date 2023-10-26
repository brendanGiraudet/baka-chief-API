using bakaChiefApplication.API.Services;
using bakaChiefApplication.API.Services.ProductInfoService;
using Microsoft.AspNetCore.Mvc;

namespace bakaChiefApplication.API.Controllers;

[Route("api/import")]
[ApiController]
public class ImportController : ControllerBase
{
    readonly IProductInfoService _productInfoService;

    public ImportController(IProductInfoService productInfoService)
    {
        _productInfoService = productInfoService;
    }

    [HttpGet]
    public async Task<IActionResult> Import()
    {
        var filePath = "./test.csv";
        var products = CsvDataReader.ReadCsvFile(filePath);

        Console.WriteLine($"nb produits {products.Count()}");

        await _productInfoService.CreateProductInfosAsync(products);

        return Ok(products);
    }
}

