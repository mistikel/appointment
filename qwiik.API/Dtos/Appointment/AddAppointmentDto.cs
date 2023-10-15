namespace qwiik.API.Dtos.Appointment
{
    public class AddAppointmentDto 
    {
        public string Title { get; set; } = "Title";
        public string Description { get; set; } = "Description";
        public DateTime Date { get; set; } = DateTime.Now;
        public string Address { get; set; } = "Address";
    }
}