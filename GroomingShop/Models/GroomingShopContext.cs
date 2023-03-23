using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GroomingShop.Models
{
  public class GroomingShopContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<ParentPet> ParentPets { get; set; }

    public GroomingShopContext(DbContextOptions options) : base(options) { }
  }
}