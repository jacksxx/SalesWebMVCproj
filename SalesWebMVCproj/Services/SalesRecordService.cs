using Microsoft.EntityFrameworkCore;
using SalesWebMVCproj.Models;
using System.Linq;

namespace SalesWebMVCproj.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebMVCprojContext _context;

        public SalesRecordService(SalesWebMVCprojContext context)
        {
            _context = context;
        }
        
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return  await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecords select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }

        public List<SalesRecord> FindTheLast(DateTime? date)
        {           

            return _context.SalesRecords
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderBy(x => x.Date)                
                .ToList();
        }
    }
}
