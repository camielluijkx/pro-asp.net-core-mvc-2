using Microsoft.AspNetCore.Mvc;
using Cities.Models;

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Cities);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            repository.AddCity(city);

            return RedirectToAction("Index");
        }
    }
}