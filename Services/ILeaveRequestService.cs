using Capstone.DTOs;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Services
{
    public interface ILeaveRequestService
    {
        IEnumerable<LeaveRequestDTO> GetAllLeave();
        LeaveRequestDTO GetLeaveById(int LeaveId);

        LeaveRequest CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO);
        void UpdateLeaveRequest(int leaveId, LeaveRequestDTO leaveRequestDTO);
        void DeleteLeaveRequest(int LeaveId);
    }
}