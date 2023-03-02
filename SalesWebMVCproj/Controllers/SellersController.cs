using Microsoft.AspNetCore.Mvc;

namespace SalesWebMVCproj.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
