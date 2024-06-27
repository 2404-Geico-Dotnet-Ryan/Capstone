using Capstone.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Services
{
    public interface IPerformanceService
    {
        Task<ActionResult<PerformanceDTO>> GetByEmployeeIdAndReviewPeriod(int employeeId, string reviewPeriod);
    }



}