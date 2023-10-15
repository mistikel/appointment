using Microsoft.EntityFrameworkCore;
using qwiik.Api.Models;

    public class AppointmentContext : DbContext
    {
        public AppointmentContext (DbContextOptions<AppointmentContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointment { get; set; } = default!;

        public DbSet<DayOff> DayOff { get; set; } = default!;

        public DbSet<AppointmentLimit> AppointmentLimit { get; set; } = default!;
    }
