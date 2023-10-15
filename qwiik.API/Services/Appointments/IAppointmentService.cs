using qwiik.Api.Dtos.Appointment;
using qwiik.Api.Models;

namespace qwiik.Api.Service.Appointments
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