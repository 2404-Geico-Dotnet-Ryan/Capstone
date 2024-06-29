using Capstone.DTOs;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Services
{
    public interface ILeaveRequestService
    {
        IEnumerable<LeaveRequestDTO> GetAllLeave();
        LeaveRequestDTO GetLeaveById(int LeaveId);
        LeaveRequestDTO CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO);
        LeaveRequestDTO UpdateLeaveRequest(int leaveId, LeaveRequestDTO leaveRequestDTO);
        void DeleteLeaveRequest(int leaveId);
        Task<LeaveEmailDTO> BuildLeaveRequestDTO(int leaveId);
    }
}