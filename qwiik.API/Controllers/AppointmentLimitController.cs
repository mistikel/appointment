using Microsoft.AspNetCore.Mvc;
using qwiik.API.Dtos.AppointmentRule;
using qwiik.API.Models;
using qwiik.API.Service.AppointmentRules;

namespace qwiik.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentLimitController : ControllerBase
    {
        private readonly IAppointmentRules _appointmentRules;

        public AppointmentLimitController(IAppointmentRules appointmentRules)
        {
            _appointmentRules = appointmentRules;
        }

        // GET: api/AppointmentLimit
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentLimit>>> GetAppointmentLimit()
        {
          return Ok(await _appointmentRules.GetAppointmentLimit());
        }

        // POST: api/AppointmentLimit
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppointmentLimit>> PostAppointmentLimit(AddAppointmentLimitDto appointmentLimit)
        {
            return Ok(await _appointmentRules.AddAppointmentLimit(appointmentLimit));
        }

    }
}
