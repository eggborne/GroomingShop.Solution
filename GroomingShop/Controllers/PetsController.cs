using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GroomingShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace GroomingShop.Controllers
{
  public class PetsController : Controller
  {
    private readonly GroomingShopContext _db;

    public PetsController(GroomingShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Pet> model = _db.Pets.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Pet Pet)
    {
      _db.Pets.Add(Pet);

      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Pet thisPet = _db.Pets.FirstOrDefault(Pet => Pet.PetId == id);
      return View(thisPet);
    }

    public ActionResult Edit(int id)
    {
      Pet thisPet = _db.Pets.FirstOrDefault(Pet => Pet.PetId == id);
      return View(thisPet);
    }

    [HttpPost]
    public ActionResult Edit(Pet Pet)
    {
      _db.Pets.Update(Pet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Pet thisPet = _db.Pets.FirstOrDefault(Pet => Pet.PetId == id);
      return View(thisPet);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Pet thisPet = _db.Pets.FirstOrDefault(Pet => Pet.PetId == id);
      _db.Pets.Remove(thisPet);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
