using Capstone.DTOs;
using Capstone.Models;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Services
{
    public interface IPerformanceService
    {
        Task<ActionResult<PerformanceDTO>> GetByEmployeeIdAndReviewPeriod(int employeeId, string reviewPeriod);
        IEnumerable<PerformanceDTO> GetAllPerformanceReviews();
        Performance AddPerformanceReview(PerformanceDTO performanceDTO);
        PerformanceDTO UpdatePerformance(int performanceId, PerformanceDTO updatedPerformanceDTO);

        PerformanceDTO UpdatePerformanceReviewByEmployeeIdAndReviewPeriod(int employeeId, string reviewPeriod, PerformanceDTO updatedPerformanceDTO);
        void DeletePerformance(int performanceId);

        Task<LeaveEmailDTO> BuildPerformanceRequestDTO(int leaveId);
    }



}