using qwiik.Api.Dtos.AppointmentRule;
using qwiik.Api.Models;

namespace qwiik.Api.Service.AppointmentRules
{
    public interface IAppointmentRules
    {
        Task<ServiceResponse<List<GetAppointmentLimitDto>>> GetAppointmentLimit();
        Task<ServiceResponse<GetAppointmentLimitDto>> AddAppointmentLimit(AddAppointmentLimitDto addAppointmentLimitDto);
        Task<ServiceResponse<List<GetDayOffDto>>> GetDayOff();
        Task<ServiceResponse<GetDayOffDto>> AddDayOff(AddDayOffDto addDayOffDto);
    }
}