using Microsoft.AspNetCore.Mvc;

namespace MVC_Database_Template.Controllers
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