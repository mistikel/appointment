using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qwiik.API.Dtos.AppointmentRule;
using qwiik.API.Models;

using qwiik.API.Service.AppointmentRules;
namespace qwiik.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayOffController : ControllerBase
    {
        private readonly IAppointmentRules _appointmentRules;

        public DayOffController(IAppointmentRules appointmentRules)
        {
            _appointmentRules = appointmentRules;
        }

        // GET: api/DayOff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayOff>>> GetDayOff()
        {
          return Ok(await _appointmentRules.GetDayOff());
        }



        // POST: api/DayOff
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DayOff>> PostDayOff(AddDayOffDto dayOff)
        {
          return Ok(await _appointmentRules.AddDayOff(dayOff));
        }
    }
}
