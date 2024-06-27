using Capstone.DTOs;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Services
{
    public interface IPerformanceService
    {
        Task<ActionResult<PerformanceDTO>> GetByEmployeeIdAndReviewPeriod(int employeeId, string reviewPeriod);
        IEnumerable<PerformanceDTO> GetAllPerformances();
        Performance AddPerformance(PerformanceDTO performanceDTO);
        PerformanceDTO UpdatePerformance(int performanceId, PerformanceDTO updatedPerformanceDTO);
        void DeletePerformance(int performanceId);
    }



}