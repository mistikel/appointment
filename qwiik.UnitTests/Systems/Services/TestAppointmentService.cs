using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using qwiik.Api;
using qwiik.Api.Dtos.Appointment;
using qwiik.Api.Models;
using qwiik.Api.Service.Appointments;

namespace qwiik.UnitTests.Systems.Services;

public class TestAppointmentService : IDisposable
{
    protected readonly AppointmentContext _context;
    private readonly IMapper _mapper;

    public TestAppointmentService()
    {
        var options = new DbContextOptionsBuilder<AppointmentContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

        _context = new AppointmentContext(options);
        var autoMapperProfile = new AutoMapperProfile();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(autoMapperProfile));
        _mapper = new Mapper(configuration);

        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task GetAllAppointments_ReturnAppointmentList()
    {
        var data = MockData.AppointmentMockData.GetAppointments();
        var appointments = data.Data.Select(d => _mapper.Map<Appointment>(d)).ToList();
        _context.Appointment.AddRange(appointments);
        _context.SaveChanges();

        var service = new AppointmentService(_mapper, _context);
        var result = await service.GetAllAppointments();

        result.Success.Should().Be(true);
        result.Data.Should().HaveCount(data.Data.Count());
    }

    [Fact]
    public async Task GetAppointmentById_ReturnAppointment()
    {
        var data = MockData.AppointmentMockData.GetAppointment();
        var appointment = _mapper.Map<Appointment>(data.Data);
        _context.Appointment.AddRange(appointment);
        _context.SaveChanges();

        var service = new AppointmentService(_mapper, _context);
        var result = await service.GetAppointmentById(1);

        result.Success.Should().Be(true);
        result.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task Update_ReturnAppointment()
    {
        var data = MockData.AppointmentMockData.GetAppointment();
        var appointment = _mapper.Map<Appointment>(data.Data);
        _context.Appointment.AddRange(appointment);
        _context.SaveChanges();

       var uAppointment = new UpdateAppointmentDto
        {
            Title= "Title",
            Description= "Description",
            Address= "Address",
            Date=DateTime.Now
        };
        var service = new AppointmentService(_mapper, _context);
        var result = await service.UpdateAppointment(1, uAppointment);

        result.Success.Should().Be(true);
    }

    [Fact]
    public async Task DeleteAppointment_ReturnAppointment()
    {
        var data = MockData.AppointmentMockData.GetAppointment();
        var appointment = _mapper.Map<Appointment>(data.Data);
        _context.Appointment.AddRange(appointment);
        _context.SaveChanges();

        var service = new AppointmentService(_mapper, _context);
        var result = await service.DeleteAppointment(1);

        result.Success.Should().Be(true);
        result.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task CreateAppointment_ReturnAppointment()
    {
        var service = new AppointmentService(_mapper, _context);
        var newAppointment = new AddAppointmentDto
        {
            Title= "Title",
            Description= "Description",
            Address= "Address",
            Date=DateTime.Now
        };

        var result = await service.CreateAppointments(newAppointment);

        result.Success.Should().Be(true);
        result.Data.Should().NotBeNull();
    }


    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

}