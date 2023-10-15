namespace qwiik.API.Dtos.AppointmentRule
{
    public class GetAppointmentLimitDto 
    {
         public long Id { get; set; }
         public DateTime Date { get; set; }
         public long Limit {get; set;} = 10;
    }
}