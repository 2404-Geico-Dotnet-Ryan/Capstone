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
        private readonly IPerformanceService _performanceService;

        public PerformanceController(IPerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        [HttpGet]

        public ActionResult<IEnumerable<PerformanceDTO>> GetPerformanceReviews()
        {
            var performances = _performanceService.GetAllPerformanceReviews();
            return Ok(performances);
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

        [HttpPost]
        public ActionResult<PerformanceDTO> PostPerformance(PerformanceDTO performanceDTO)
        {
            var performance = _performanceService.AddPerformanceReview(performanceDTO);

            return CreatedAtAction(nameof(GetPerformanceReviews), new { performancId = performance.PerformanceId }, performanceDTO);
        }

        //tested in swagger (without entering goals as DB was empty at the time), passing
        [HttpPut("{performanceId}")]
        public ActionResult<PerformanceDTO> UpdatePerformance(int performanceId, PerformanceDTO updatedPerformance)
        {
            _performanceService.UpdatePerformance(performanceId, updatedPerformance);
            return Ok(updatedPerformance);
        }

        //tested in swagger, passing
        [HttpDelete("{performanceId}")]
        public IActionResult DeletePerformance(int performanceId)
        {
            _performanceService.DeletePerformance(performanceId);
            return Ok();
        }
    }
}