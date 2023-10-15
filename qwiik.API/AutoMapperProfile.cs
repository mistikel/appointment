using AutoMapper;
using qwiik.API.Dtos.Appointment;
using qwiik.API.Dtos.AppointmentRule;
using qwiik.API.Models;

namespace qwiik.API
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Appointment,GetAppointmentDto>(); 
            CreateMap<AddAppointmentDto, Appointment>(); 
            CreateMap<AppointmentLimit, GetAppointmentLimitDto>(); 
            CreateMap<AddAppointmentLimitDto, AppointmentLimit>(); 
            CreateMap<DayOff, GetDayOffDto>(); 
            CreateMap<AddDayOffDto, DayOff>(); 
            CreateMap<UpdateAppointmentDto, Appointment>(); 
        }
    }
}