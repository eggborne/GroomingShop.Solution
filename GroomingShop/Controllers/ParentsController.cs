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
      List<Parent> model = _db.Parents
                          .Include(parent => parent.JoinEntities)
                          .ThenInclude(join => join.Pet)
                          .ToList();
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
                          .Include(parent => parent.JoinEntities)
                          .ThenInclude(join => join.Pet)
                          .FirstOrDefault(parent => parent.ParentId == id);
      return View(thisParent);
    }

    public ActionResult Edit(int id)
    {
      Parent thisParent = _db.Parents.FirstOrDefault(parent => parent.ParentId == id);
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
      Parent thisParent = _db.Parents.FirstOrDefault(parent => parent.ParentId == id);
      return View(thisParent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Parent thisParent = _db.Parents.FirstOrDefault(parent => parent.ParentId == id);
      _db.Parents.Remove(thisParent);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult AddPet(Pet pet, int parentId)
    {
      _db.Pets.Add(pet);
      _db.SaveChanges();
      #nullable enable
      ParentPet? joinEntity = _db.ParentPets.FirstOrDefault(join => (join.PetId == pet.PetId && join.ParentId == parentId));
      #nullable disable
      if (joinEntity == null && parentId != 0)
      {
        _db.ParentPets.Add(new ParentPet() { PetId = pet.PetId, ParentId = parentId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
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
