using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GroomingShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace GroomingShop.Controllers
{
  public class ParentsController : Controller
  {
    private readonly GroomingShopContext _db;

    public ParentsController(GroomingShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Parent> model = _db.Parents.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Parent Parent)
    {
      _db.Parents.Add(Parent);

      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Parent thisParent = _db.Parents
                          .Include(Parent => Parent.JoinEntities)
                          .ThenInclude(join => join.Pet)
                          .FirstOrDefault(Parent => Parent.ParentId == id);
      return View(thisParent);
    }

    public ActionResult Edit(int id)
    {
      Parent thisParent = _db.Parents.FirstOrDefault(Parent => Parent.ParentId == id);
      return View(thisParent);
    }

    [HttpPost]
    public ActionResult Edit(Parent Parent)
    {
      _db.Parents.Update(Parent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Parent thisParent = _db.Parents.FirstOrDefault(Parent => Parent.ParentId == id);
      return View(thisParent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Parent thisParent = _db.Parents.FirstOrDefault(Parent => Parent.ParentId == id);
      _db.Parents.Remove(thisParent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddPet(int id)
    {
      Parent thisParent = _db.Parents.FirstOrDefault(items => items.ParentId == id);
      ViewBag.PetId = new SelectList(_db.Pets, "PetId", "Name");
      return View(thisParent);
    }

    [HttpPost]
    public ActionResult AddPet(Parent Parent, int petId)
    {
      #nullable enable
      ParentPet? joinEntity = _db.ParentPets.FirstOrDefault(join => (join.PetId == petId && join.ParentId == Parent.ParentId));
      #nullable disable
      if (joinEntity == null && petId != 0)
      {
        _db.ParentPets.Add(new ParentPet() { PetId = petId, ParentId = Parent.ParentId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = Parent.ParentId });
    }

     [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      ParentPet joinEntry = _db.ParentPets.FirstOrDefault(entry => entry.ParentPetId == joinId);
      _db.ParentPets.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
