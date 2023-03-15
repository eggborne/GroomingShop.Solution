using Microsoft.EntityFrameworkCore;

namespace GroomingShop.Models
{
  public class GroomingShopContext : DbContext
  {
    public DbSet<Groomer> Groomers { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<ParentPet> ParentPets { get; set; }

    public GroomingShopContext(DbContextOptions options) : base(options) { }
  }
}