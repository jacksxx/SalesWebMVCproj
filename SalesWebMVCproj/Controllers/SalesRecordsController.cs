using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVCproj.Controllers
{
    public class SalesRecordsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleSearch()
        {
            return View();
        }

        public IActionResult GroupSearch()
        {
            return View();
        }
    }
}
