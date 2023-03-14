using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GroomingShop.Models;
using System.Collections.Generic;
using System.Linq;

namespace GroomingShop.Controllers
{
  public class GroomersController : Controller
  {
    private readonly GroomingShopContext _db;

    public GroomersController(GroomingShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Groomer> model = _db.Groomers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Groomer groomer)
    {
      _db.Groomers.Add(groomer);

      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Groomer thisGroomer = _db.Groomers
                          .Include(groomer => groomer.Appointments)
                          .FirstOrDefault(groomer => groomer.GroomerId == id);
      return View(thisGroomer);
    }

    public ActionResult Edit(int id)
    {
      Groomer thisGroomer = _db.Groomers.FirstOrDefault(groomer => groomer.GroomerId == id);
      return View(thisGroomer);
    }

    [HttpPost]
    public ActionResult Edit(Groomer groomer)
    {
      _db.Groomers.Update(groomer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Groomer thisGroomer = _db.Groomers.FirstOrDefault(groomer => groomer.GroomerId == id);
      return View(thisGroomer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Groomer thisGroomer = _db.Groomers.FirstOrDefault(groomer => groomer.GroomerId == id);
      _db.Groomers.Remove(thisGroomer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
