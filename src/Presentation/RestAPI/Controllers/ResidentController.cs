using Application.DTOs.Resident;
using Application.Interfaces.Data;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/residents")]
    [ApiController]
    public class ResidentController : ControllerBase
    {
        private readonly IResidentRepository _resident;

        public ResidentController(IResidentRepository resident)
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
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }
    }
}
