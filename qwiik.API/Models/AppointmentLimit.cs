namespace qwiik.API.Models;

public class AppointmentLimit
{
    public long Id { get; set; }
    public DateTime Date { get; set; }
    public long Limit {get; set;} = 10;
}