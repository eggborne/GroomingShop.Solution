
using System.Collections.Generic;
using System;

namespace GroomingShop.Models
{
  public class Appointment
  {
    public int AppointmentId { get; set; }
    public int ParentId { get; set; }
    public int PetId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
    public float Price { get; set; }
    public string Notes { get; set; }

    public Parent Parent { get; set; }
    public Pet Pet { get; set; }
    public Employee Employee { get; set; }
  }
}