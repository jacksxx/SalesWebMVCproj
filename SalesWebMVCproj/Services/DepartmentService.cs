using SalesWebMVCproj.Models;
using System.Collections.Generic;

namespace SalesWebMVCproj.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCprojContext _context;

        public DepartmentService(SalesWebMVCprojContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
