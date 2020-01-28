using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Linq;
using UsingViewComponents.Models;

namespace UsingViewComponents.Components
{
    public class CitySummary : ViewComponent
    {
        private ICityRepository repository;

        public CitySummary(ICityRepository repo)
        {
            repository = repo;
        }

        //public string Invoke()
        //{
        //    return $"{repository.Cities.Count()} cities, "
        //        + $"{repository.Cities.Sum(c => c.Population)} people";
        //}

        //public IViewComponentResult Invoke()
        //{
        //    CityViewModel model = new CityViewModel
        //    {
        //        Cities = repository.Cities.Count(),
        //        Population = repository.Cities.Sum(c => c.Population)
        //    };

        //    return View(model);
        //}

        //public IViewComponentResult Invoke()
        //{
        //    string result = "This is a <h3><i>string</i></h3>");

        //    return Content(result);
        //}

        //public IViewComponentResult Invoke()
        //{
        //    HtmlString result = new HtmlString("This is a <h3><i>string</i></h3>");

        //    return new HtmlContentViewComponentResult(result);
        //}

        //public IViewComponentResult Invoke()
        //{
        //    string target = RouteData.Values["id"] as string;

        //    var cities = repository.Cities
        //        .Where(city => target == null || 
        //            string.Compare(city.Country, target, true) == 0);

        //    CityViewModel model = new CityViewModel
        //    {
        //        Cities = cities.Count(),
        //        Population = repository.Cities.Sum(c => c.Population)
        //    };

        //    return View(model);
        //}

        public IViewComponentResult Invoke(bool showList)
        {
            if (showList)
            {
                return View("CityList", repository.Cities);
            }
            else
            {
                CityViewModel model = new CityViewModel
                {
                    Cities = repository.Cities.Count(),
                    Population = repository.Cities.Sum(c => c.Population)
                };

                return View(model);
            }
        }
    }
}