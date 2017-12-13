
using Microsoft.AspNetCore.Mvc;

namespace UnitTestProject.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }

}