using bakaChiefApplication.API.DatabaseModels;
using bakaChiefApplication.API.Services.RecipsService;
using Microsoft.AspNetCore.Mvc;

namespace bakaChiefApplication.API.Controllers
{
    [Route("api/recips")]
    [ApiController]
    public class RecipsController : ControllerBase
    {
        private readonly IRecipsService _recipService;

        public RecipsController(IRecipsService recipService)
        {
            _recipService = recipService ?? throw new ArgumentNullException(nameof(recipService));
        }

        [HttpGet]
        public async Task<IActionResult> GetRecips()
        {
            var recips = await _recipService.GetRecipsAsync();
            return Ok(recips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipById(string id)
        {
            var recip = await _recipService.GetRecipByIdAsync(id);
            if (recip == null)
            {
                return NotFound();
            }
            return Ok(recip);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecip(Recip recip)
        {
            await _recipService.CreateRecipAsync(recip);
            return CreatedAtAction(nameof(GetRecipById), new { id = recip.Id }, recip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecip(string id, Recip recip)
        {
            if (id != recip.Id)
            {
                return BadRequest();
            }

            await _recipService.UpdateRecipAsync(recip);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecip(string id)
        {
            var recip = await _recipService.GetRecipByIdAsync(id);
            if (recip == null)
            {
                return NotFound();
            }

            await _recipService.DeleteRecipAsync(id);

            return NoContent();
        }
    }
}
