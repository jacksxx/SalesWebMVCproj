using Microsoft.AspNetCore.Mvc;
using SalesWebMVCproj.Models;
using SalesWebMVCproj.Services;

namespace SalesWebMVCproj.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,BirthDate,BaseSalary")] Seller seller)
        {

            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));

        }
    }
}
