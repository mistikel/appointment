namespace qwiik.API.Dtos.AppointmentRule
{
    public class AddAppointmentLimitDto 
    {
        public DateTime Date { get; set; }
        public long Limit {get; set;} = 10;
    }
}