using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private readonly UptimeService _uptimeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UptimeService uptimeService, ILogger<HomeController> logger)
        {
            _uptimeService = uptimeService;
            _logger = logger;
        }

        public ViewResult Index(bool throwException = false)
        {
            _logger.LogDebug($"Handled {Request.Path} at uptime {_uptimeService.Uptime}");

            if (throwException)
            {
                throw new System.NullReferenceException();
            }

            var model = new Dictionary<string, string>
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{_uptimeService.Uptime}ms"
            };

            return View(model);
        }

        public ViewResult Error()
        {
            var model = new Dictionary<string, string>
            {
                ["Message"] = "This is the Error action"
            };

            return View(nameof(Index), model);
        }
    }
}