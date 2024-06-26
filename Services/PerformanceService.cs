using Capstone.Models;
using Capstone.DTOs;
using Capstone.Data;

namespace Capstone.Services
{
    public class PerformanceService : IPeformanceService
    {
        private readonly AppDbContext _context;

        public PerformanceService(AppDbContext context)
        {
            _context = context;
        }
    }
}
