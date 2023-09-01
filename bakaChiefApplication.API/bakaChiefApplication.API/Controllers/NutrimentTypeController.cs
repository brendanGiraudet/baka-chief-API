using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Services.NutrimentTypeService;
using Microsoft.AspNetCore.Mvc;

namespace bakaChiefApplication.API.Controllers
{
    [Route("api/nutrimentTypes")]
    [ApiController]
    public class NutrimentTypeController : ControllerBase
    {
        private readonly INutrimentTypeService _nutrimentTypeService;

        public NutrimentTypeController(INutrimentTypeService nutrimentTypeService)
        {
            _nutrimentTypeService = nutrimentTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNutrimentType(NutrimentType nutrimentType)
        {
            await _nutrimentTypeService.CreateNutrimentTypeAsync(nutrimentType);

            return StatusCode(StatusCodes.Status201Created, nutrimentType);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NutrimentType>> GetNutrimentTypeById(string id)
        {
            var nutrimentType = await _nutrimentTypeService.GetNutrimentTypeByIdAsync(id);
            if (nutrimentType == null)
            {
                return NotFound($"The nutriment type { id } doesn't exist");
            }
            return Ok(nutrimentType);
        }

        [HttpGet]
        public async Task<ActionResult<List<NutrimentType>>> GetAllNutrimentTypes()
        {
            var nutrimentTypes = await _nutrimentTypeService.GetAllNutrimentTypesAsync();
            return Ok(nutrimentTypes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNutrimentType(string id, NutrimentType nutrimentType)
        {
            if (id != nutrimentType.Id)
            {
                return BadRequest();
            }

            await _nutrimentTypeService.UpdateNutrimentTypeAsync(nutrimentType);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutrimentType(string id)
        {
            await _nutrimentTypeService.DeleteNutrimentTypeAsync(id);
            return Ok();
        }
    }
}
