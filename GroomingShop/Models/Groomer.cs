
using System.Collections.Generic;

namespace GroomingShop.Models
{
  public class Groomer
  {
    public int GroomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Appointment> Appointments { get; set;}
  }
}