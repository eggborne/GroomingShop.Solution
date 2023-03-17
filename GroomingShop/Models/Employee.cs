
using System.Collections.Generic;
using System;

namespace GroomingShop.Models
{
  public class Employee
  {
    public int EmployeeId { get; set; }
    public string Position { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string AlternatePhone { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string EmergencyContact { get; set; }
    public string EmergencyPhone { get; set; }
    public string Notes { get; set; }
    public DateTime HireDate { get; set; }
    public List<Appointment> Appointments { get; set;}
  }
}