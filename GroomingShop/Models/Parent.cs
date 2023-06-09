using System.Collections.Generic;

namespace GroomingShop.Models
{
  public class Parent
  {
    public int ParentId { get; set; }
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
    public List<ParentPet> JoinEntities { get; }
  }
}