using Application.DTOs.Resident;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/residents")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService _resident;

        public ResidentController(IResidentService resident)
        {
            _resident = resident;
        }

        [HttpGet]
        public async Task<IActionResult> GetResidentsAsync()
        {
            var residents = await _resident.GetAsync();
            
            return Ok(residents);
        }

        [HttpGet("{id}", Name = nameof(ResidentController.GetResidentByIdAsync))]
        public async Task<IActionResult> GetResidentByIdAsync(int id)
        {
            var resident = await _resident.GetByIdAsync(id);
            if (resident is null)
            {
                return NotFound();
            }

            return Ok(resident);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateResidentAsync([FromBody] CreateResidentDTO createResidentDto)
        {
            var record = await _resident.CreateAsync(createResidentDto);

            if (record is null)
                return BadRequest("Failed");

            return CreatedAtRoute(nameof(ResidentController.GetResidentByIdAsync), new { id = record.Id }, record);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResidentAsync([FromRoute] int id, [FromBody] UpdateResidentDTO updateResidentDto)
        {
            var isSuccess = await _resident.UpdateAsync(id, updateResidentDto);

            if (!isSuccess)
                return NotFound();

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidentAsync([FromRoute] int id)
        {
            var isSuccess = await _resident.DeleteAsync(id);

            if (!isSuccess)
                return NotFound();

            return NoContent();
        }
    }
}
