using Microsoft.AspNetCore.Mvc;
using SalesWebMVCproj.Models;
using System.Collections.Generic;
namespace SalesWebMVCproj.Controllers
{
    public class DepartmantsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });

            return View(list);
        }
    }
}
