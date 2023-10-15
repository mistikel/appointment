using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using qwiik.Api.Controllers;
using qwiik.Api.Dtos.Appointment;
using qwiik.Api.Service.Appointments;
using qwiik.UnitTests.MockData;
namespace qwiik.UnitTests.Systems.Controllers;


public class TestAppointmentController
{
    [Fact]
    public async Task GetAllAppointment_ShouldReturn200Status() 
    {
        var appointmentService = new Mock<IAppointmentService>();
        appointmentService.Setup(_ => _.GetAllAppointments()).ReturnsAsync(AppointmentMockData.GetAppointments());
        var controller = new AppointmentController(appointmentService.Object);

        var result = await controller.GetAllAppointment();
        var okObjectResult = result.Result as OkObjectResult;
        okObjectResult?.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task GetAppointment_ShouldReturn200Status() 
    {
        var appointmentService = new Mock<IAppointmentService>();
        appointmentService.Setup(_ => _.GetAppointmentById(1)).ReturnsAsync(AppointmentMockData.GetAppointment());
        var controller = new AppointmentController(appointmentService.Object);

        var result = await controller.GetAppointment(1);
        var okObjectResult = result.Result as OkObjectResult;
        okObjectResult?.StatusCode.Should().Be(200);
    }   

    [Fact]
    public async Task PostAppointment_ShouldCall_IAppointmentService_CreateAppointments_AtLeastOnce() 
    {
        var appointmentService = new Mock<IAppointmentService>();
        var controller = new AppointmentController(appointmentService.Object);
        
        var newAppointment = new AddAppointmentDto
        {
            Title= "Title",
            Description= "Description",
            Address= "Address",
            Date=DateTime.Now
        };

        appointmentService.Setup(_ => _.CreateAppointments(newAppointment)).ReturnsAsync(AppointmentMockData.GetAppointment());
        var result = await controller.PostAppointment(newAppointment);
        var okObjectResult = result.Result as OkObjectResult;
        okObjectResult?.StatusCode.Should().Be(200);
        appointmentService.Verify(_ => _.CreateAppointments(newAppointment), Times.Exactly(1));
    }

    [Fact]
    public async Task DeleteAppointment_ShouldCall_IAppointmentService_DeleteAppointments_AtLeastOnce() 
    {
        var appointmentService = new Mock<IAppointmentService>();
        var controller = new AppointmentController(appointmentService.Object);
        appointmentService.Setup(_ => _.DeleteAppointment(1)).ReturnsAsync(AppointmentMockData.GetAppointment());
        var result = (OkObjectResult)await controller.DeleteAppointment(1);
        result?.StatusCode.Should().Be(200);
        appointmentService.Verify(_ => _.DeleteAppointment(1), Times.Exactly(1));
    }   

    [Fact]
    public async Task PutAppointment_ShouldCall_IAppointmentService_PutAppointments_AtLeastOnce() 
    {
        var appointmentService = new Mock<IAppointmentService>();
        var controller = new AppointmentController(appointmentService.Object);
        var uAppointment = new UpdateAppointmentDto
        {
            Title= "Title",
            Description= "Description",
            Address= "Address",
            Date=DateTime.Now
        };
        appointmentService.Setup(_ => _.UpdateAppointment(1, uAppointment)).ReturnsAsync(AppointmentMockData.GetAppointment());
        var result = await controller.PutAppointment(1, uAppointment);
        var okObjectResult = result.Result as OkObjectResult;
        okObjectResult?.StatusCode.Should().Be(200);
        appointmentService.Verify(_ => _.UpdateAppointment(1, uAppointment), Times.Exactly(1));
    }   
}