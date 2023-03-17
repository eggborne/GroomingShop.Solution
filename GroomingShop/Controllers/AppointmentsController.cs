using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using GroomingShop.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace GroomingShop.Controllers
{
  public class AppointmentsController : Controller
  {
    private readonly GroomingShopContext _db;

    public AppointmentsController(GroomingShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Appointment> model = _db.Appointments
                                .Include(appointment => appointment.Employee)
                                .Include(appointment => appointment.Parent)
                                .Include(appointment => appointment.Pet)
                                .ToList();
      return View(model);
    }

  
    #nullable enable
    public ActionResult Create(int id)
    {
      ViewBag.Employee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == id);
      ViewBag.ParentId = new SelectList(_db.Parents, "ParentId", "LastName");
      ViewBag.PetId = new SelectList(_db.Pets, "PetId", "Name");
      return View();
    }
    #nullable disable

    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
      try 
      {
        _db.Appointments.Add(appointment);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      catch(DbUpdateException error)
      {
        ViewBag.ClassName = "overlap";
        ViewBag.ErrorMessage = error.InnerException.Message;
        ViewBag.Employee = _db.Employees.FirstOrDefault(employee => employee.EmployeeId == appointment.EmployeeId);
        ViewBag.ParentId = new SelectList(_db.Parents, "ParentId", "LastName");
        ViewBag.PetId = new SelectList(_db.Pets, "PetId", "Name");
        return View();
      }

    }

    public ActionResult Details(int id)
    {
      Appointment thisAppointment = _db.Appointments
                                    .Include(appointment => appointment.Employee)
                                    .Include(appointment => appointment.Parent)
                                    .Include(appointment => appointment.Pet)
                                    .FirstOrDefault(appointment => appointment.AppointmentId == id);
      return View(thisAppointment);
    }

    public ActionResult Edit(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      return View(thisAppointment);
    }

    [HttpPost]
    public ActionResult Edit(Appointment appointment)
    {
      _db.Appointments.Update(appointment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      return View(thisAppointment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Appointment thisAppointment = _db.Appointments.FirstOrDefault(appointment => appointment.AppointmentId == id);
      _db.Appointments.Remove(thisAppointment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
