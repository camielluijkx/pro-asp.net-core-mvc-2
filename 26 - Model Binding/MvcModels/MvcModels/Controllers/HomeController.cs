using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        //public IActionResult Index(int id)
        //{
        //    /*

        //    http://localhost:51015/Home/Index/1             => repository[1]
        //    http://localhost:51015/Home/Index/3?id=1        => repository[3]
        //    http://localhost:51015/Home/Index/0             => repository[0] => NullReferenceException
        //    http://localhost:51015/Home/Index               => repository[default(int)] thus repository[0] => NullReferenceException

        //    */

        //    return View(repository[id]);
        //}

        //public IActionResult Index(int id)
        //{
        //    return View(repository[id] ?? repository.People.First()); // incorrect result
        //}

        //public IActionResult Index(int? id)
        //{
        //    /*

        //    http://localhost:51015/Home/Index/1             => repository[1]
        //    http://localhost:51015/Home/Index/3?id=1        => repository[3]
        //    http://localhost:51015/Home/Index/0             => repository[0] => 404
        //    http://localhost:51015/Home/Index               => repository[default(int)] thus repository[0] => 404

        //    */

        //    Person person;

        //    if (id.HasValue && (person = repository[id.Value]) != null)
        //    {
        //        return View(person);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        public IActionResult Index([FromQuery] int? id)
        {
            //    /*

            //    http://localhost:51015/Home/Index/1             => repository[default(int)] thus repository[0] => 404
            //    http://localhost:51015/Home/Index/3?id=1        => repository[1]
            //    http://localhost:51015/Home/Index/0             => repository[default(int)] thus repository[0] => 404
            //    http://localhost:51015/Home/Index               => repository[default(int)] thus repository[0] => 404

            //    */

            Person person;

            if (id.HasValue && (person = repository[id.Value]) != null)
            {
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }

        public ViewResult Create()
        {
            return View(new Person());
        }

        [HttpPost]
        public ViewResult Create(Person model)
        {
            return View("Index", model);
        }

        public ViewResult DisplaySummary([Bind(Prefix = nameof(Person.HomeAddress))] AddressSummary summary)
        //public ViewResult DisplaySummary([Bind(nameof(AddressSummary.City), Prefix = nameof(Person.HomeAddress))] AddressSummary summary)
        {
            return View(summary);
        }

        //public ViewResult Names(string[] names)
        //{
        //    return View(names ?? new string[0]);
        //}

        public ViewResult Names(IList<string> names)
        {
            return View(names ?? new List<string>());
        }

        public ViewResult Address(IList<AddressSummary> addresses)
        {
            return View(addresses ?? new List<AddressSummary>());
        }

        //public string Header([FromHeader] string accept)
        //{
        //    // Header: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9
        //    return $"Header: {accept}";
        //}

        //public string Header([FromHeader(Name = "Accept-Language")] string accept)
        //{
        //    // Header: en-US,en;q=0.9,nl;q=0.8s
        //    return $"Header: {accept}";
        //}

        public ViewResult Header(HeaderModel model)
        {
            return View(model);
        }

        public ViewResult Body()
        {
            return View();
        }

        [HttpPost]
        public Person Body([FromBody]Person model)
        {
            return model;
        }
    }
}