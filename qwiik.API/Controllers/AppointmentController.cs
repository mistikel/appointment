using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using qwiik.Api.Dtos.Appointment;
using qwiik.Api.Models;
using qwiik.Api.Service.Appointments;

namespace qwiik.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/Appointment
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Appointment>>>> GetAllAppointment()
        {
          return Ok(await _appointmentService.GetAllAppointments());
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Appointment>>> GetAppointment(long id)
        {
          return Ok(await _appointmentService.GetAppointmentById(id));
        }


        // POST: api/Appointment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Appointment>>> PostAppointment(AddAppointmentDto addAppointmentDto)
        {
          var result = await _appointmentService.CreateAppointments(addAppointmentDto);
          if (!result.Success) {
            return BadRequest(result);
          } 

          return Ok(result);
        }
       
        // DELETE: api/appointment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await _appointmentService.DeleteAppointment(id);
            if (!result.Success) {
              return BadRequest(result);
            } 

            return Ok(result);
        }

        // PUT: api/appointment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Appointment>>> PutAppointment(int id, UpdateAppointmentDto updateAppointmentDto)
        {
            
             var result = await _appointmentService.UpdateAppointment(id, updateAppointmentDto);
            if (!result.Success) {
              return BadRequest(result);
            } 

            return Ok(result);
        }

    }
}
