using bakaChiefApplication.API.Services.NutrimentTypeService;
using Microsoft.AspNetCore.Mvc;

namespace bakaChiefApplication.API.Controllers
{
    [ApiController]
    [Route("nutrimentType")]
    public class NutrimentTypeController : ControllerBase
    {
        private readonly INutrimentTypeService _nutrimentTypeService;

        public NutrimentTypeController(INutrimentTypeService nutrimentTypeService)
        {
            _nutrimentTypeService = nutrimentTypeService;
        }

        [HttpGet(Name = "GetNutrimentType")]
        public async Task<IActionResult> Get()
        {
            var nutrimentTypes = await _nutrimentTypeService.GetAllNutrimentTypesAsync();

            if (nutrimentTypes.Count == 0) return NoContent();

            return StatusCode(StatusCodes.Status200OK, nutrimentTypes);
        }
    }
}