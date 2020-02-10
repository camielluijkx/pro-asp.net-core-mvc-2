using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var model = new Dictionary<string, object> { ["Placeholder"] = "Placeholder" };

            return View(model);
        }
    }
}