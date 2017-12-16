using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitTestProject.Web.Models;

namespace UnitTestProject.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            var products = new List<Product>{
                new Product { ID = 1, Name = "Apples", Price = 1.50m },
                new Product { ID = 2, Name = "Bananas", Price = 2.00m }
            };

            return View(products);
        }
    }

}