using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index1()
        {
            return View("/Views/Admin/Index");
        }

        public ViewResult Index2()
        {
            return View("/Views/Admin/Index.cshtml");
        }

        public ViewResult Index3()
        {
            return View(DateTime.Now);
        }

        public ViewResult Index4()
        {
            //return View("Hello World");
            return View((object)"Hello World");
        }

        public ViewResult Index5()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;

            return View("Index");
        }

        public JsonResult Index6()
        {
            return Json(new[] { "Alice", "Bob", "Joe" });
        }

        public ContentResult Index7()
        {
            return Content("[\"Alice\",\"Bob\",\"Joe\"]", "application/json");
        }

        public ObjectResult Index8() // content negotiation
        {
            // Headers -> Accept:
            // text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9

            return Ok(new string[] { "Alice", "Bob", "Joe" });
        }

        public VirtualFileResult Index9()
        {
            return File("/lib/bootstrap/dist/css/bootstrap.css", "text/css");
        }

        public StatusCodeResult Index10()
        {
            return StatusCode(StatusCodes.Status404NotFound);
        }

        public StatusCodeResult Index()
        {
            return NotFound();
        }

        public RedirectResult Redirect1()
        {
            return Redirect("/Example/Index");
        }

        public RedirectResult Redirect2()
        {
            return RedirectPermanent("/Example/Index");
        }

        public RedirectToRouteResult Redirect3()
        {
            object routeValues = new
            {
                controller = "Example",
                action = "Index",
                ID = "MyID"
            };

            return RedirectToRoute(routeValues);
        }

        public RedirectToRouteResult Redirect4()
        {
            object routeValues = new
            {
                controller = "Example",
                action = "Index",
                ID = "MyID"
            };

            return RedirectToRoutePermanent(routeValues);
        }

        public RedirectToActionResult Redirect5()
        {
            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult Redirect6()
        {
            return RedirectToActionPermanent(nameof(Index));
        }

        public RedirectToActionResult Redirect7()
        {
            return RedirectToAction(nameof(HomeController), nameof(HomeController.Index));
        }

        public RedirectToActionResult Redirect8()
        {
            return RedirectToActionPermanent(nameof(HomeController), nameof(HomeController.Index));
        }
    }
}