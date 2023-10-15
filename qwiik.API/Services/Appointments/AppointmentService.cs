using AutoMapper;
using Microsoft.EntityFrameworkCore;
using qwiik.Api.Dtos.Appointment;
using qwiik.Api.Models;

namespace qwiik.Api.Service.Appointments
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly AppointmentContext _context;

        public AppointmentService(IMapper mapper, AppointmentContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<GetAppointmentDto>> CreateAppointments(AddAppointmentDto addAppointmentDto)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            var appointment = _mapper.Map<Appointment>(addAppointmentDto);
            var appointmentInDate =  _context.Appointment.Where(c => c.Date.Date == addAppointmentDto.Date.Date).Count();
            var appointmentLimit =  await _context.AppointmentLimit.SingleOrDefaultAsync(c => c.Date.Date == addAppointmentDto.Date.Date);
            if (appointmentLimit  != null && appointmentInDate != 0) 
            {
                    if (appointmentInDate >= appointmentLimit.Limit)
                    {
                        appointment.Date = addAppointmentDto.Date.AddDays(1);
                    }
            }

            var dayOff = await _context.DayOff.SingleOrDefaultAsync(c => c.Date.Date == addAppointmentDto.Date.Date);
            if (dayOff != null ) 
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed create appointment on day Off, please select another day";
                return serviceResponse;
            }

            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetAppointmentDto>(appointment);
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetAppointmentDto>> DeleteAppointment(int id)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            try 
            {
                var dbAppointment = await _context.Appointment.FirstAsync(c => c.Id == id) ?? throw new Exception($"Appointment with Id '{id}' not found.");
                _context.Appointment.Remove(dbAppointment);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetAppointmentDto>(dbAppointment);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
           
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments()
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>();
            var dbAppointment = await _context.Appointment.ToListAsync();
            serviceResponse.Data = dbAppointment.Select(d => _mapper.Map<GetAppointmentDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(long id)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            try 
            {
                var dbAppointment = await _context.Appointment.FirstAsync(c => c.Id == id);
                serviceResponse.Data = _mapper.Map<GetAppointmentDto>(dbAppointment);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(int id, UpdateAppointmentDto updateAppointmentDto)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentDto>();
            try 
            {
               var dbAppointment = await _context.Appointment.FirstAsync(c => c.Id == id);
               dbAppointment.Title = updateAppointmentDto.Title;
               dbAppointment.Address = updateAppointmentDto.Address;
               dbAppointment.Date = updateAppointmentDto.Date;
               dbAppointment.Description = updateAppointmentDto.Description;
               await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
           
            return serviceResponse;
        }
    }
}