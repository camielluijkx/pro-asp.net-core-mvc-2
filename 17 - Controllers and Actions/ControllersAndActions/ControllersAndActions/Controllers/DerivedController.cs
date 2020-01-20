using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ControllersAndActions.Controllers
{
    public class DerivedController : Controller
    {
        public ViewResult Index()
        {
            return View("Result", $"This is a derived controller");
        }

        public ViewResult Headers()
        {
            Dictionary<string, string> model = Request.Headers
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First());

            return View("DictionaryResult", model);
        }
    }
}