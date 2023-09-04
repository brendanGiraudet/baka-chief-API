using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Services.NutrimentsService;
using Microsoft.AspNetCore.Mvc;

namespace bakaChiefApplication.API.Controllers
{
    [Route("api/nutriments")]
    [ApiController]
    public class NutrimentsController : ControllerBase
    {
        private readonly INutrimentsService _nutrimentsService;

        public NutrimentsController(INutrimentsService nutrimentTypeService)
        {
            _nutrimentsService = nutrimentTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNutrimentAsync(Nutriment nutriment)
        {
            await _nutrimentsService.CreateNutrimentAsync(nutriment);

            return StatusCode(StatusCodes.Status201Created, nutriment);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Nutriment>> GetNutrimentByIdAsync(string id)
        {
            var nutriment = await _nutrimentsService.GetNutrimentByIdAsync(id);
            if (nutriment == null)
            {
                return NotFound($"The nutriment {id} doesn't exist");
            }

            return Ok(nutriment);
        }

        [HttpGet]
        public async Task<ActionResult<List<Nutriment>>> GetNutrimentsAsync()
        {
            var nutriments = await _nutrimentsService.GetNutrimentsAsync();

            return Ok(nutriments);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNutrimentAsync(string id, Nutriment nutriment)
        {
            if (id != nutriment.Id)
            {
                return BadRequest();
            }

            await _nutrimentsService.UpdateNutrimentAsync(nutriment);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutrimentAsync(string id)
        {
            await _nutrimentsService.DeleteNutrimentAsync(id);
            return Ok();
        }
    }
}
