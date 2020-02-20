using ConventionsAndConstraints.Infrastructure;
using ConventionsAndConstraints.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConventionsAndConstraints.Controllers
{
    //[AdditionalActions]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            };

            return View("Result", model);

            /*
            
            http://localhost:57580/Home/Index

            */
        }

        [ActionName("Index")]
        [UserAgent("Edge")]
        public IActionResult Other()
        {
            var model = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Other)
            };

            return View("Result", model);

            /*
            
            http://localhost:57580/Home/Other

            AmbiguousActionException: Multiple actions matched. The following actions matched route data and had all constraints satisfied:


            */
        }

        [UserAgent("Edge")]
        //[ActionName("Details")]
        //[ActionNamePrefix("Do")]
        [AddAction("Details")]
        public IActionResult List()
        {
            var model = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(List)
            };

            return View("Result", model);

            /*
            
            http://localhost:57580/Home/List
            http://localhost:57580/Home/Details
            http://localhost:57580/Home/DoList

            InvalidOperationException: Collection was modified; enumeration operation may not execute.

            */
        }
    }
}