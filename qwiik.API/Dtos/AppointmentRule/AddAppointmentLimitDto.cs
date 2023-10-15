namespace qwiik.Api.Dtos.AppointmentRule
{
    public class AddAppointmentLimitDto 
    {
        public DateTime Date { get; set; }
        public long Limit {get; set;} = 10;
    }
}