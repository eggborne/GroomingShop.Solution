using System.Collections.Generic;
using System;

namespace GroomingShop.Models
{
  public class Pet
  {
    public int PetId { get; set; }
    public string Name { get; set; }
    public string Breed { get; set; }
    public int Weight { get; set; }
    public char Gender { get; set; }
    public string Color { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime VaccExpDate { get; set; }
    public string Vet { get; set; }
    public string VetPhone { get; set; }
    public string Notes { get; set; }
    public List<ParentPet> JoinEntities { get; }
  }
}