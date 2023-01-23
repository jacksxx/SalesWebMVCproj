using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVCproj.Models
{
    public class SalesWebMVCprojContext : DbContext
    {
        public SalesWebMVCprojContext (DbContextOptions<SalesWebMVCprojContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMVCproj.Models.Department> Department { get; set; } = default!;
    }
}
