using Capstone.Data;
using Microsoft.AspNetCore.Mvc;
using Capstone.DTOs;
using Capstone.Services;

namespace Capstone.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PerformanceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PerformanceService _performanceService; 

        public PerformanceController(AppDbContext context, PerformanceService performanceService)
        {
            _context = context;
            _performanceService = performanceService; 
        }

        [HttpGet("{employeeId}/{reviewPeriod}")]
        public async Task<ActionResult<PerformanceDTO>> GetByEmployeeIdAndReviewPeriod(int employeeId, string reviewPeriod)
        {
            var performance = await _performanceService.GetByEmployeeIdAndReviewPeriod(employeeId, reviewPeriod); 

            if (performance == null)
            {
                return NotFound();
            }

            return performance; 
        }
    }
}