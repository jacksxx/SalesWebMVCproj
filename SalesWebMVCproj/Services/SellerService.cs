using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebMVCproj.Models;

namespace SalesWebMVCproj.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCprojContext _context;

        public SellerService(SalesWebMVCprojContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
