namespace GroomingShop.Models
{
public class ParentPet
  {
    public int ParentPetId { get; set; }
    public int ParentId { get; set; }
    public Parent Parent { get; set; }
    public int PetId { get; set; }
    public Pet Pet { get; set; }
  }
}