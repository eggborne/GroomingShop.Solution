
using System.Collections.Generic;
using System;

namespace GroomingShop.Models
{
  public class Groomer
  {
    public int GroomerId { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime HireDate { get; set; }
    public string Notes { get; set; }
    public List<Appointment> Appointments { get; set;}
  }
}