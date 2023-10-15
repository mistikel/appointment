using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qwiik.Api.Models;

public class Appointment
{
    public long Id { get; set; }
    [MaxLength(150), Column(TypeName = "nvarchar(150)")]
    public string Title { get; set; } = "Title";
    [MaxLength(300), Column(TypeName = "nvarchar(300)")]
    public string Description { get; set; } = "Description";
public DateTime Date { get; set; } = DateTime.Now;
    [MaxLength(100), Column(TypeName = "nvarchar(100)")]
    public string Address { get; set; } = "Address";

}