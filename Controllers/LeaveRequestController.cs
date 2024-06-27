
using System.Runtime.CompilerServices;
using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LeaveRequestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public LeaveRequestDTO CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO)
        {
            var leaveRequest = new LeaveRequest
            {
                LeaveId = leaveRequestDTO.LeaveId,
                EmployeeId = leaveRequestDTO.EmployeeId,
                ManagerId = leaveRequestDTO.ManagerId,
                LeaveType = leaveRequestDTO.LeaveType,
                LeaveStartDate = leaveRequestDTO.LeaveStartDate,
                LeaveEndDate = leaveRequestDTO.LeaveEndDate,
                HoursTaken = leaveRequestDTO.HoursTaken,
                IsApproved = leaveRequestDTO.IsApproved
            };
            _context.LeaveRequests.Add(leaveRequest);
            _context.SaveChanges();
            return leaveRequestDTO;
        }

        [HttpDelete("{LeaveId}")]
        public void DeleteLeaveRequest(int LeaveId)
        {
            var leaveRequest = _context.LeaveRequests.FirstOrDefault(l => l.LeaveId == LeaveId);
            if (leaveRequest != null)
            {
                _context.LeaveRequests.Remove(leaveRequest);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Leave request not found");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<LeaveRequestDTO>> GetLeaveRequests()
        {
            var leaveRequest = _context.LeaveRequests.Select(l => new LeaveRequestDTO
            {
                LeaveId = l.LeaveId,
                EmployeeId = l.EmployeeId,
                ManagerId = l.ManagerId,
                LeaveType = l.LeaveType,
                LeaveStartDate = l.LeaveStartDate,
                LeaveEndDate = l.LeaveEndDate,
                HoursTaken = l.HoursTaken,
                IsApproved = l.IsApproved
            }).ToList();
            return leaveRequest;
        }

        [HttpGet("{LeaveId}")]
        public ActionResult<LeaveRequestDTO> GetLeaveRequest(int LeaveId)
        {
            var leaveRequest = _context.LeaveRequests.Select(l => new LeaveRequestDTO
            {
                LeaveId = l.LeaveId,
                EmployeeId = l.EmployeeId,
                ManagerId = l.ManagerId,
                LeaveType = l.LeaveType,
                LeaveStartDate = l.LeaveStartDate,
                LeaveEndDate = l.LeaveEndDate,
                HoursTaken = l.HoursTaken,
                IsApproved = l.IsApproved
            }).FirstOrDefault(l => l.LeaveId == LeaveId);
            if (leaveRequest == null)
            {
                return NotFound();

            }
            return leaveRequest;
        }
        [HttpPut("{LeaveId}")]
        public ActionResult<LeaveRequestDTO> UpdateLeaveRequest(int LeaveId, LeaveRequestDTO leaveRequestDTO)
        {
            var leaveRequest = _context.LeaveRequests.FirstOrDefault(l => l.LeaveId == LeaveId);
            if (leaveRequestDTO == null)
            {
                return NotFound();
            }
                leaveRequest.LeaveId = leaveRequestDTO.LeaveId;
                leaveRequest.EmployeeId = leaveRequestDTO.EmployeeId;
                leaveRequest.ManagerId = leaveRequestDTO.ManagerId;
                leaveRequest.LeaveType = leaveRequestDTO.LeaveType;
                leaveRequest.LeaveStartDate = leaveRequestDTO.LeaveStartDate;
                leaveRequest.LeaveEndDate = leaveRequestDTO.LeaveEndDate;
                leaveRequest.HoursTaken = leaveRequestDTO.HoursTaken;
                leaveRequest.IsApproved = leaveRequestDTO.IsApproved;
            _context.SaveChanges();
            return leaveRequestDTO;

        }
    }
}