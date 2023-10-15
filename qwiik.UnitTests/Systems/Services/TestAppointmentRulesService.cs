using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using qwiik.Api;
using qwiik.Api.Dtos.AppointmentRule;
using qwiik.Api.Service.AppointmentRules;

namespace qwiik.UnitTests.Systems.Services;

public class TestAppointmentRulesService : IDisposable
{
    protected readonly AppointmentContext _context;
    private readonly IMapper _mapper;

    public TestAppointmentRulesService()
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
    public async Task CreateDayOff_ReturnDayoff()
    {
        var service = new AppointmentRuleService(_mapper, _context);
        var newDayoff = new AddDayOffDto
        {
            Date=DateTime.Now
        };

        var result = await service.AddDayOff(newDayoff);

        result.Success.Should().Be(true);
        result.Data.Should().NotBeNull();
    }

    [Fact]
    public async Task CreateAppointmentLimit_ReturnAppointmentLimit()
    {
        var service = new AppointmentRuleService(_mapper, _context);
        var newAppointmentLimit = new AddAppointmentLimitDto
        {
            Date=DateTime.Now,
            Limit=10
        };

        var result = await service.AddAppointmentLimit(newAppointmentLimit);

        result.Success.Should().Be(true);
        result.Data.Should().NotBeNull();
    }
    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}