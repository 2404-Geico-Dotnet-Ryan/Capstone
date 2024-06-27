using Capstone.Models;
using Capstone.DTOs;
using Capstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Services
{
    public class PerformanceService : IPerformanceService
    {
        private readonly AppDbContext _context;

        public PerformanceService(AppDbContext context)
        {
            _context = context;
        }

        //GET Perf Review by EmployeeId AND ReviewPeriod
        public async Task<ActionResult<PerformanceDTO>> GetByEmployeeIdAndReviewPeriod (int employeeId, string reviewPeriod)
        {
            var performance = await _context.Performances
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.EmployeeId == employeeId && p.ReviewPeriod == reviewPeriod);

            if (performance == null)
            {
                return null;
            }
            var performanceDTO = ConvertToDTO(performance);
            
            return performanceDTO;
        }

        // Helper method to convert Performance to PerformanceDTO
        private PerformanceDTO ConvertToDTO(Performance performance)
        {
            var performanceDto = new PerformanceDTO
            {
                PerformanceId = performance.PerformanceId,
                EmployeeId = performance.EmployeeId,
                ManagerId = performance.ManagerId,
                ReviewPeriod = performance.ReviewPeriod,
                Achievements = performance.Achievements,
                ImprovementAreas = performance.ImprovementAreas,
                TotalReviewScore = performance.TotalReviewScore,
                IsCompletedPA = performance.IsCompletedPA,
                IsCompletedReview = performance.IsCompletedReview,
                // Goals = goals.Select(g => new GoalsDTO
                // {
                //     GoalId = g.GoalId,
                //     PerformanceId = g.PerformanceId,
                //     Goal = g.Goal,
                //     Deliverable = g.Deliverable,
                //     Deadline = g.Deadline,
                //     Weightage = g.Weightage,
                //     GoalScore = g.GoalScore,
                //     ManagerFeedback = g.ManagerFeedback
                // }).ToList()
            };

            return performanceDto;
        }
    }
}
