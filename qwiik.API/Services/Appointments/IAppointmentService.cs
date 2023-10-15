using qwiik.API.Dtos.Appointment;
using qwiik.API.Models;

namespace qwiik.API.Service.Appointments
{
    public interface IAppointmentService
    {
        Task<ServiceResponse<List<GetAppointmentDto>>> GetAllAppointments();
        Task<ServiceResponse<GetAppointmentDto>> GetAppointmentById(long id);
        Task<ServiceResponse<GetAppointmentDto>> CreateAppointments(AddAppointmentDto addAppointmentDto);
        Task<ServiceResponse<GetAppointmentDto>> DeleteAppointment(int id);
        Task<ServiceResponse<GetAppointmentDto>> UpdateAppointment(int id, UpdateAppointmentDto updateAppointmentDto);
    }
}