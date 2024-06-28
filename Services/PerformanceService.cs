using Capstone.Models;
using Capstone.DTOs;
using Capstone.Data;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
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


        // POST Performance Review
        public Performance AddPerformanceReview(PerformanceDTO performanceDTO)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == performanceDTO.EmployeeId);

            var performance = new Performance
            {
                Employee = employee,
                ManagerId = performanceDTO.ManagerId,
                ReviewPeriod = performanceDTO.ReviewPeriod,
                Achievements = performanceDTO.Achievements,
                ImprovementAreas = performanceDTO.ImprovementAreas,
                TotalReviewScore = performanceDTO.TotalReviewScore,
                IsCompletedPA = performanceDTO.IsCompletedPA,
                IsCompletedReview = performanceDTO.IsCompletedReview
            };
            _context.Performances.Add(performance);
            _context.SaveChanges();

            return performance;
        }

        public IEnumerable<PerformanceDTO>GetAllPerformanceReviews()
        {
            var performances = _context.Performances
                .Include(p => p.Employee)
                .Select(p => new PerformanceDTO
                {
                    PerformanceId = p.PerformanceId,
                    EmployeeId = p.EmployeeId,
                    ManagerId = p.ManagerId,
                    ReviewPeriod = p.ReviewPeriod,
                    Achievements = p.Achievements,
                    ImprovementAreas = p.ImprovementAreas,
                    TotalReviewScore = p.TotalReviewScore,
                    IsCompletedPA = p.IsCompletedPA,
                    IsCompletedReview = p.IsCompletedReview

                }).ToList();
            return performances;
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

        // Update performance review by Manager- retrieve review by Employee ID and Review Period

        public PerformanceDTO UpdatePerformanceReviewByEmployeeIdAndReviewPeriod (int employeeId, string reviewPeriod, PerformanceDTO updatedPerformanceDTO)
        {
            var performance = _context.Performances
                .Include(p => p.Employee)
                .FirstOrDefault(P => P.EmployeeId == employeeId && P.ReviewPeriod == reviewPeriod);
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == updatedPerformanceDTO.EmployeeId);
            
            if (performance == null)
            {
                return null;
            }
            performance.ReviewPeriod = updatedPerformanceDTO.ReviewPeriod;
            performance.Achievements = updatedPerformanceDTO.Achievements;
            performance.ImprovementAreas = updatedPerformanceDTO.ImprovementAreas;
            performance.TotalReviewScore = updatedPerformanceDTO.TotalReviewScore;
            performance.IsCompletedPA = updatedPerformanceDTO.IsCompletedPA;
            performance.IsCompletedReview = updatedPerformanceDTO.IsCompletedReview;
            performance.Employee = employee;

            _context.Performances.Update(performance);
            _context.SaveChanges();
            return updatedPerformanceDTO;

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



        public void DeletePerformance(int performanceId)
        {
            var performance = _context.Performances.Find(performanceId);
            if (performance != null)
            {
                _context.Performances.Remove(performance);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception ("Performance not found");
            }
        }

        public PerformanceDTO UpdatePerformance(int performanceId, PerformanceDTO updatedPerformanceDTO)
        {
            var performance = _context.Performances
                .Include(p => p.Employee)
                .Include(p => p.Goals)
                .FirstOrDefault(p => p.PerformanceId == performanceId);
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == updatedPerformanceDTO.EmployeeId);
            // var goal = _context.

            if (performance == null)
            {
                return null;
            }

            performance.ReviewPeriod = updatedPerformanceDTO.ReviewPeriod;
            performance.Achievements = updatedPerformanceDTO.Achievements;
            performance.ImprovementAreas = updatedPerformanceDTO.ImprovementAreas;
            performance.TotalReviewScore = updatedPerformanceDTO.TotalReviewScore;
            performance.IsCompletedPA = updatedPerformanceDTO.IsCompletedPA;
            performance.IsCompletedReview = updatedPerformanceDTO.IsCompletedReview;
            performance.Employee = employee;
            // performance.Goals = goal;

            _context.Performances.Update(performance);
            _context.SaveChanges();
            return updatedPerformanceDTO;
        }




}
}
