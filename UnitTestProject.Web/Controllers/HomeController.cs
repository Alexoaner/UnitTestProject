using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnitTestProject.Web.Models;
using UnitTestProject.Web.Repositorys;

namespace UnitTestProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository productRepository;

        public HomeController(IProductRepository _repository)
        {
            productRepository = _repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            return View(productRepository.ListProducts());
        }

        public IActionResult Details(int id)
        {
            var product = productRepository.GetProductById(id);

            if (product == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(product);
            }
        }
    }

}