using SalesWebMVCproj.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVCproj.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCprojContext _context;

        public DepartmentService(SalesWebMVCprojContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
