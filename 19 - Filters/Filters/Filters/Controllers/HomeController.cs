using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Filters.Controllers
{
    //public class HomeController : Controller
    //{
    //    public ViewResult Index()
    //    {
    //        return View("Message", "This is the Index action on the Home controller");
    //    }
    //}

    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        if (!Request.IsHttps)
    //        {
    //            return new StatusCodeResult(StatusCodes.Status403Forbidden);
    //        }
    //        else
    //        {
    //            return View("Message", "This is the Index action on the Home controller");
    //        }
    //    }

    //    public IActionResult SecondAction()
    //    {
    //        if (!Request.IsHttps)
    //        {
    //            return new StatusCodeResult(StatusCodes.Status403Forbidden);
    //        }
    //        else
    //        {
    //            return View("Message", "This is the SecondAction action on the Home controller");
    //        }
    //    }
    //}

    //// will trigger a redirect is request scheme is not https, redirect will fail when running on different port
    //[RequireHttps]
    //public class HomeController : Controller
    //{
    //    //[RequireHttps]
    //    public IActionResult Index()
    //    {
    //        return View("Message", "This is the Index action on the Home controller");
    //    }

    //    //[RequireHttps]
    //    public IActionResult SecondAction()
    //    {
    //        return View("Message", "This is the SecondAction action on the Home controller");
    //    }
    //}

    //[HttpsOnly]
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View("Message", "This is the Index action on the Home controller");
    //    }

    //    public IActionResult SecondAction()
    //    {
    //        return View("Message", "This is the SecondAction action on the Home controller");
    //    }
    //}

    //[Profile]
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View("Message", "This is the Index action on the Home controller");
    //    }

    //    public IActionResult SecondAction()
    //    {
    //        return View("Message", "This is the SecondAction action on the Home controller");
    //    }
    //}

    //[Profile]
    //[ViewResultDetails]
    //[RangeException]
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View("Message", "This is the Index action on the Home controller");
    //    }

    //    public IActionResult SecondAction()
    //    {
    //        return View("Message", "This is the SecondAction action on the Home controller");
    //    }

    //    public ViewResult GenerateException(int? id)
    //    {
    //        if (id == null)
    //        {
    //            throw new ArgumentNullException(nameof(id));
    //        }
    //        else if (id > 10)
    //        {
    //            throw new ArgumentOutOfRangeException(nameof(id));
    //        }
    //        else
    //        {
    //            return View("Message", $"The value is {id}");
    //        }
    //    }
    //}

    //[TypeFilter(typeof(DiagnosticsFilter))]
    //[TypeFilter(typeof(TimeFilter))]
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View("Message", "This is the Index action on the Home controller");
    //    }

    //    public IActionResult SecondAction()
    //    {
    //        return View("Message", "This is the SecondAction action on the Home controller");
    //    }

    //    public ViewResult GenerateException(int? id)
    //    {
    //        if (id == null)
    //        {
    //            throw new ArgumentNullException(nameof(id));
    //        }
    //        else if (id > 10)
    //        {
    //            throw new ArgumentOutOfRangeException(nameof(id));
    //        }
    //        else
    //        {
    //            return View("Message", $"The value is {id}");
    //        }
    //    }
    //}

    //[TypeFilter(typeof(DiagnosticsFilter))]
    //[ServiceFilter(typeof(TimeFilter))]
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View("Message", "This is the Index action on the Home controller");
    //    }

    //    public IActionResult SecondAction()
    //    {
    //        return View("Message", "This is the SecondAction action on the Home controller");
    //    }

    //    public ViewResult GenerateException(int? id)
    //    {
    //        if (id == null)
    //        {
    //            throw new ArgumentNullException(nameof(id));
    //        }
    //        else if (id > 10)
    //        {
    //            throw new ArgumentOutOfRangeException(nameof(id));
    //        }
    //        else
    //        {
    //            return View("Message", $"The value is {id}");
    //        }
    //    }
    //}

    [Message("This is the Controller-Scoped Filter", Order = 10)]
    public class HomeController : Controller
    {
        [Message("This is the First Action-Scoped Filter", Order = 1)]
        [Message("This is the Second Action-Scoped Filter", Order = -1)]
        public ViewResult Index() => View("Message",
            "This is the Index action on the Home controller");
    }
}