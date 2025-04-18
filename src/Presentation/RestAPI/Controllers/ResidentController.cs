using Application.DTOs.Resident;
using Application.Interfaces.Data;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/residents")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentService _residentService;

        public ResidentController(IResidentService resident)
        {
            _residentService = resident;
        }

        [HttpGet]
        public async Task<IActionResult> GetResidentsAsync()
        {
            var residents = await _residentService.GetAsync();
            
            return Ok(residents);
        }

        [HttpGet("{id}", Name = nameof(ResidentController.GetResidentByIdAsync))]
        public async Task<IActionResult> GetResidentByIdAsync(int id)
        {
            var resident = await _residentService.GetByIdAsync(id);
            if (resident is null)
            {
                return NotFound();
            }

            return Ok(resident);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateResidentAsync([FromBody] CreateResidentDTO createResidentDto)
        {
            var record = await _residentService.CreateAsync(createResidentDto);

            if (record is null)
                return BadRequest("Failed");

            return CreatedAtRoute(nameof(ResidentController.GetResidentByIdAsync), new { id = record.Id }, record);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateResidentAsync([FromRoute] int id, [FromBody] UpdateResidentDTO updateResidentDto)
        {
            var isSuccess = await _residentService.UpdateAsync(id, updateResidentDto);

            if (!isSuccess)
                return NotFound();

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidentAsync([FromRoute] int id)
        {
            var isSuccess = await _residentService.DeleteAsync(id);

            if (!isSuccess)
                return NotFound();

            return NoContent();
        }
    }
}
