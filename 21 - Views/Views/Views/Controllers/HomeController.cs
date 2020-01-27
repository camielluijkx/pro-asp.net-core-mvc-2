using Microsoft.AspNetCore.Mvc;
using System;

namespace Views.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index()
        //{
        //    ViewBag.Message = "Hello, World";
        //    ViewBag.Time = DateTime.Now.ToString("HH:mm:ss");

        //    return View("DebugData");
        //}

        public ViewResult Index()
        {
            object model = new string[] { "Apple", "Orange", "Pear" };

            return View("MyView", model);
        }

        public ViewResult List()
        {
            return View();
        }
    }
}