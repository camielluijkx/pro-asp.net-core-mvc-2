using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
    public class HomeController : Controller
    {
        public IRepository Repository = SimpleRepository.SharedRepository;

        //public IActionResult Index() => View(Repository.Products
        //    .Where(prop => prop?.Price < 50));
        public IActionResult Index() => View(Repository.Products);

        [HttpGet]
        public IActionResult AddProduct() => View(new Product());

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            Repository.AddProduct(p);

            return RedirectToAction("Index");
        }
    }
}