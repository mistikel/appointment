using AutoMapper;
using qwiik.Api.Dtos.Appointment;
using qwiik.Api.Dtos.AppointmentRule;
using qwiik.Api.Models;

namespace qwiik.Api
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Appointment,GetAppointmentDto>(); 
            CreateMap<AddAppointmentDto, Appointment>(); 
            CreateMap<GetAppointmentDto, Appointment>(); 
            CreateMap<AppointmentLimit, GetAppointmentLimitDto>(); 
            CreateMap<AddAppointmentLimitDto, AppointmentLimit>(); 
            CreateMap<DayOff, GetDayOffDto>(); 
            CreateMap<AddDayOffDto, DayOff>(); 
            CreateMap<UpdateAppointmentDto, Appointment>(); 
        }
    }
}