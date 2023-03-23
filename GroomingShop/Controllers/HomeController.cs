using Microsoft.AspNetCore.Mvc;

using GroomingShop.Models;

namespace GroomingShop.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpPost()]
      public ActionResult Index(ApplicationUser applicationUser)
      {
        return View();
      }

    }
}