using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using qwiik.Api.Controllers;
using qwiik.Api.Dtos.AppointmentRule;
using qwiik.Api.Service.AppointmentRules;
using qwiik.UnitTests.MockData;

namespace qwiik.UnitTests.Systems.Controllers;

public class TestAppointmentLimitController
{
    [Fact]
    public async Task GeAppointmentLimit_ShouldReturn200Status() 
    {
        var appointmentService = new Mock<IAppointmentRules>();
        appointmentService.Setup(_ => _.GetAppointmentLimit()).ReturnsAsync(AppointmentMockData.GetAppointmentLimits());
        var controller = new AppointmentLimitController(appointmentService.Object);

        var result = await controller.GetAppointmentLimit();
        var okObjectResult = result.Result as OkObjectResult;
        okObjectResult?.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task PostAppointmentLimit_ShouldCall_IAppointmentRule_AddAppointmentLimit_AtLeastOnce() 
    {
        var appointmentService = new Mock<IAppointmentRules>();
        var controller = new AppointmentLimitController(appointmentService.Object);
        
        var newAppointmentLimit = new AddAppointmentLimitDto
        {
            Date=DateTime.Now,
            Limit=10
        };

        appointmentService.Setup(_ => _.AddAppointmentLimit(newAppointmentLimit)).ReturnsAsync(AppointmentMockData.GetAppointmentLimit());
        var result = await controller.PostAppointmentLimit(newAppointmentLimit);
        var okObjectResult = result.Result as OkObjectResult;
        okObjectResult?.StatusCode.Should().Be(200);
        appointmentService.Verify(_ => _.AddAppointmentLimit(newAppointmentLimit), Times.Exactly(1));
    }

}