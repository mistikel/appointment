namespace qwiik.Api.Dtos.Appointment
{
    public class GetAppointmentDto 
    {
        public long Id { get; set; }
        public string Title { get; set; } = "Title";
        public string Description { get; set; } = "Description";
        public DateTime Date { get; set; } = DateTime.Now;
        public string Address { get; set; } = "Address";
        public bool Deleted { get; set; } = false;
    }
}