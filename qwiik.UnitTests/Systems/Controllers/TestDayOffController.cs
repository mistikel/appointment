using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using qwiik.Api.Controllers;
using qwiik.Api.Dtos.AppointmentRule;
using qwiik.Api.Service.AppointmentRules;
using qwiik.UnitTests.MockData;

namespace qwiik.UnitTests.Systems.Controllers;

public class TestDayOffController
{
    [Fact]
    public async Task GeDayOff_ShouldReturn200Status() 
    {
        var appointmentService = new Mock<IAppointmentRules>();
        appointmentService.Setup(_ => _.GetDayOff()).ReturnsAsync(AppointmentMockData.GetDayOffs());
        var controller = new DayOffController(appointmentService.Object);

        var result = await controller.GetDayOff();
        var okObjectResult = result.Result as OkObjectResult;
        okObjectResult?.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task PostDayOff_ShouldCall_IAppointmentRules_AddDayOff_AtLeastOnce() 
    {
        var appointmentService = new Mock<IAppointmentRules>();
        var controller = new DayOffController(appointmentService.Object);
        
        var newDayOff = new AddDayOffDto
        {
            Date=DateTime.Now,
        };

        appointmentService.Setup(_ => _.AddDayOff(newDayOff)).ReturnsAsync(AppointmentMockData.GetDayOff());
        var result = await controller.PostDayOff(newDayOff);
        var okObjectResult = result.Result as OkObjectResult;
        okObjectResult?.StatusCode.Should().Be(200);
        appointmentService.Verify(_ => _.AddDayOff(newDayOff), Times.Exactly(1));
    }
}