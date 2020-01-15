using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class AdminController : Controller
    {
        public ViewResult Index()
        {
            Result result = new Result
            {
                Controller = nameof(AdminController),
                Action = nameof(Index)
            };

            return View("Result", result);
        }
    }
}