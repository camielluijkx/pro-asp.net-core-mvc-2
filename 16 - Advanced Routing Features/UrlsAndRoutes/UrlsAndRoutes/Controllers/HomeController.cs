using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Result result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(Index)
            };

            return View("Result", result);
        }

        public ViewResult CustomVariable(string id)
        {
            Result result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariable),
            };

            result.Data["Id"] = id ?? "<no value>";
            result.Data["Url"] = Url.Action("CustomVariable", "Home", new { id = 100 });

            return View("Result", result);
        }
    }
}