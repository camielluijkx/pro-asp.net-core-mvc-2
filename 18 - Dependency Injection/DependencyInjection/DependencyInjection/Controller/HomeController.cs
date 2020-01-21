using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index1()
        //{
        //    return View();
        //}

        //public ViewResult Index2()
        //{
        //    return View(new MemoryRepository().Products);
        //}

        // loosely coupled for purpose of unit testing but tightly coupled when application is running
        //public IRepository Repository { get; set; } = new MemoryRepository();

        //public IRepository Repository { get; } = TypeBroker.Repository;

        //public ViewResult Index3()
        //{
        //    return View(Repository.Products);
        //}

        //private IRepository repository;

        //public HomeController(IRepository repo)
        //{
        //    repository = repo;
        //}

        //public ViewResult Index4()
        //{
        //    return View(repository.Products);
        //}

        //private IRepository repository;
        //private ProductTotalizer totalizer;

        //public HomeController(IRepository repo, ProductTotalizer total)
        //{
        //    repository = repo;
        //    totalizer = total;
        //}

        //public ViewResult Index5()
        //{
        //    ViewBag.Total = totalizer.Total;

        //    return View(repository.Products);
        //}

        //public ViewResult Index6()
        //{
        //    ViewBag.HomeControllerID = repository.ToString();
        //    ViewBag.TotalizerID = totalizer.Repository.ToString();

        //    return View(repository.Products);
        //}

        private IRepository repository;

        public HomeController(IRepository repo)
        {
            repository = repo;
        }

        //public ViewResult Index7([FromServices]ProductTotalizer totalizer) // action injection
        //{
        //    ViewBag.HomeControllerID = repository.ToString();
        //    ViewBag.TotalizerID = totalizer.Repository.ToString();

        //    return View(repository.Products);
        //}

        public ViewResult Index([FromServices]ProductTotalizer totalizer) // service locator pattern
        {
            IRepository repository =
                HttpContext.RequestServices.GetService<IRepository>();

            ViewBag.HomeController = repository.ToString();
            ViewBag.Totalizer = totalizer.Repository.ToString();

            return View(repository.Products);
        }
    }
}