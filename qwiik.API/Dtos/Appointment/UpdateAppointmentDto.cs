namespace qwiik.Api.Dtos.Appointment
{
    public class UpdateAppointmentDto 
    {
        public string Title { get; set; } = "Title";
        public string Description { get; set; } = "Description";
        public DateTime Date { get; set; } = DateTime.Now;
        public string Address { get; set; } = "Address";
    }
}