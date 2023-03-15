
using System.Collections.Generic;
using System;

namespace GroomingShop.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Notes { get; set; }
    public int GroomerId { get; set; }
    public Groomer Groomer { get; set; }
    public int ParentId { get; set; }
    public Parent Parent { get; set; }
    public int PetId { get; set; }
    public Pet Pet { get; set; }
  }
}