using System.Collections.Generic;

namespace GroomingShop.Models
{
  public class Parent
  {
    public int ParentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Notes { get; set; }
    public List<ParentPet> JoinEntities { get; }
  }
}