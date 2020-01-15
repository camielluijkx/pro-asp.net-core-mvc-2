using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    [Route("app/[controller]/actions/[action]/{id:weekday?}")]
    //[Route("[area]/app/[controller]/actions/[action]/{id:weekday?}")]
    public class CustomerController : Controller
    {
        public ViewResult Index()
        {
            Result result = new Result
            {
                Controller = nameof(CustomerController),
                Action = nameof(Index)
            };

            return View("Result", result);
        }

        public ViewResult List(string id)
        {
            Result result = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(List)
            };

            result.Data["id"] = id ?? "<no value>";
            result.Data["catchall"] = RouteData.Values["catchall"];

            return View("Result", result);
        }
    }
}