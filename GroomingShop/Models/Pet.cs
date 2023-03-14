using System.Collections.Generic;

namespace GroomingShop.Models
{
  public class Pet
  {
    public int PetId { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public List<ParentPet> JoinEntities { get; }
  }
}