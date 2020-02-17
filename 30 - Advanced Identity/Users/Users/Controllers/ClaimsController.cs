using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers
{
    public class ClaimsController : Controller
    {
        [Authorize]
        public ViewResult Index()
        {
            return View(User?.Claims);
        }
    }
}