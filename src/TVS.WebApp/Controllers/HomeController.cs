using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

namespace TVS.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Landlord, Admin")]
        public IActionResult LandlordHome()
        {
            return View();
        }

        [Authorize(Roles = "Tenant, Admin")]
        public IActionResult TenantHome()
        {
            return View();
        }

        [Authorize(Roles = "Society, Admin")]
        public IActionResult SocietyHome()
        {
            return View();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
