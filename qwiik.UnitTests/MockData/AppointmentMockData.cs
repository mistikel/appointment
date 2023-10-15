using qwiik.Api.Dtos.Appointment;
using qwiik.Api.Models;

namespace qwiik.UnitTests.MockData;

public class AppointmentMockData
{
    public static ServiceResponse<List<GetAppointmentDto>> GetAppointments()
    {
        var serviceResponse = new ServiceResponse<List<GetAppointmentDto>>
        {
            Data = new List<GetAppointmentDto>{
                new() {
                    Id=1,
                    Title="mock-1",
                    Description="mock-1",
                    Date= DateTime.Now,
                    Address="mock-1"
                },
                new() {
                    Id=2,
                    Title="mock-2",
                    Description="mock-2",
                    Date= DateTime.Now,
                    Address="mock-2"
                },
                new() {
                    Id=3,
                    Title="mock-3",
                    Description="mock-3",
                    Date= DateTime.Now,
                    Address="mock-3"
                }
            },
            Success = true
        };

        return serviceResponse;
        
    }

    public static ServiceResponse<GetAppointmentDto> GetAppointment()
    {
        var serviceResponse = new ServiceResponse<GetAppointmentDto>
        {
            Data = 
                new() {
                    Id=1,
                    Title="mock-1",
                    Description="mock-1",
                    Date= DateTime.Now,
                    Address="mock-1"
                },
            Success = true
        };

        return serviceResponse;
        
    }
}