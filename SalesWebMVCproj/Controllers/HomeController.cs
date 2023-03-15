using Microsoft.AspNetCore.Mvc;
using SalesWebMVCproj.Models.ViewModels;
using SalesWebMVCproj.Services;
using System.Diagnostics;

namespace SalesWebMVCproj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SalesRecordService _salesRecordService;
        public HomeController(ILogger<HomeController> logger, SalesRecordService salesRecordService)
        {
            _logger = logger;
            _salesRecordService = salesRecordService;
        }

        public  IActionResult Index()
        {
            var date = DateTime.Now;      
            
            return View(_salesRecordService.FindTheLast(date).TakeLast(5).OrderByDescending(x => x.Date));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}