using ControllersAndActions.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControllersAndActions.Controllers
{
    public class HomeController : Controller
    {
        /*
         
        Search for a View file (without usage of Areas):
        
            /Views/<ControllerName>/<ViewName>.cshtml
            /Views/Shared/<ViewName>.cshtml

        Search for a View file (wit usage of Areas):
        
            /Areas/<AreaName>/Views/<ControllerName>/<ViewName>.cshtml
            /Areas/<AreaName>/Views/Shared/<ViewName>.cshtml
            /Views/Shared/<ViewName>.cshtml

        */

        public ViewResult Index()
        {
            return View("SimpleForm");
        }

        public ViewResult ReceiveForm1()
        {
            var name = Request.Form["name"];
            var city = Request.Form["city"];

            return View("Result", $"{name} lives in {city}");
        }

        public ViewResult ReceiveForm2(string name, string city)
        {
            return View("Result", $"{name} lives in {city}");
        }

        public void ReceiveForm3(string name, string city)
        {
            Response.StatusCode = 200;
            Response.ContentType = "text/html";

            byte[] content = Encoding.ASCII.GetBytes($"<html><body>{name} lives in {city}</body></html>");

            Response.Body.WriteAsync(content, 0, content.Length);
         }

        public IActionResult ReceiveForm4(string name, string city)
        {
            CustomHtmlResult result = new CustomHtmlResult
            {
                Content = $"{name} lives in {city}"
            };

            return result;
        }

        public ViewResult Result()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult ReceiveForm(string name, string city) // Post/Redirect/Get pattern
        {
            TempData["name"] = name;
            TempData["city"] = city;

            return RedirectToAction(nameof(Data));
        }

        public ViewResult Data()
        {
            string name = TempData["name"] as string;
            string city = TempData["city"] as string;

            return View("Result", $"{name} lives in {city}");
        }
    }
}