using qwiik.API.Dtos.AppointmentRule;
using qwiik.API.Models;

namespace qwiik.API.Service.AppointmentRules
{
    public interface IAppointmentRules
    {
        Task<ServiceResponse<List<GetAppointmentLimitDto>>> GetAppointmentLimit();
        Task<ServiceResponse<GetAppointmentLimitDto>> AddAppointmentLimit(AddAppointmentLimitDto addAppointmentLimitDto);
        Task<ServiceResponse<List<GetDayOffDto>>> GetDayOff();
        Task<ServiceResponse<GetDayOffDto>> AddDayOff(AddDayOffDto addDayOffDto);
    }
}