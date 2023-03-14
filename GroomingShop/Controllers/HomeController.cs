using Microsoft.AspNetCore.Mvc;

namespace GroomingShop.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}