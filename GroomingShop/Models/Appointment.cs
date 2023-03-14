
using System.Collections.Generic;

namespace GroomingShop.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int GroomerId { get; set; }
    public Groomer Groomer { get; set; }
    public int PetId { get; set; }
    public Pet Pet { get; set; }
  }
}