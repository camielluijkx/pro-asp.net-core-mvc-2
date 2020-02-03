using Cities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

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

        public ViewResult Edit()
        {
            IEnumerable<string> cities = repository.Cities
                .Select(c => c.Country).Distinct();

            ViewBag.Countries = new SelectList(cities);

            return View("Create", repository.Cities.First());
        }

        public ViewResult Create()
        {
            IEnumerable<string> cities = repository.Cities
                .Select(c => c.Country).Distinct();

            ViewBag.Countries = new SelectList(cities);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(City city)
        {
            repository.AddCity(city);

            return RedirectToAction("Index");
        }
    }
}