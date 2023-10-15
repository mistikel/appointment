using AutoMapper;
using Microsoft.EntityFrameworkCore;
using qwiik.API.Dtos.AppointmentRule;
using qwiik.API.Models;

namespace qwiik.API.Service.AppointmentRules
{
    public class AppointmentRuleService : IAppointmentRules
    {
        private readonly IMapper _mapper;
        private readonly AppointmentContext _context;

        public AppointmentRuleService(IMapper mapper, AppointmentContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetAppointmentLimitDto>> AddAppointmentLimit(AddAppointmentLimitDto addAppointmentLimitDto)
        {
            var serviceResponse = new ServiceResponse<GetAppointmentLimitDto>();
            var appointmentLimit = _mapper.Map<AppointmentLimit>(addAppointmentLimitDto);
            _context.AppointmentLimit.Add(appointmentLimit);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetAppointmentLimitDto>(appointmentLimit);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetDayOffDto>> AddDayOff(AddDayOffDto addDayOffDto)
        {
            var serviceResponse = new ServiceResponse<GetDayOffDto>();
            var dayOff = _mapper.Map<DayOff>(addDayOffDto);
            _context.DayOff.Add(dayOff);
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetDayOffDto>(dayOff);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetAppointmentLimitDto>>> GetAppointmentLimit()
        {
            var serviceResponse = new ServiceResponse<List<GetAppointmentLimitDto>>();
            var dbAppointmentLimit = await _context.AppointmentLimit.ToListAsync();
            serviceResponse.Data = dbAppointmentLimit.Select(d => _mapper.Map<GetAppointmentLimitDto>(d)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetDayOffDto>>> GetDayOff()
        {
             var serviceResponse = new ServiceResponse<List<GetDayOffDto>>();
            var dbDayOff = await _context.DayOff.ToListAsync();
            serviceResponse.Data = dbDayOff.Select(d => _mapper.Map<GetDayOffDto>(d)).ToList();
            return serviceResponse;
        }
    }

}