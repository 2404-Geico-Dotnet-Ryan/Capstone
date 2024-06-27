using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly AppDbContext _context;

        public LeaveRequestService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<LeaveRequestDTO> GetAllLeave()
        {
            var leaveRequests = _context.LeaveRequests.ToList();
            List<LeaveRequestDTO> leaveRequestDTOs = new List<LeaveRequestDTO>();
            foreach (var leaveRequest in leaveRequests)
            {
                leaveRequestDTOs.Add(new LeaveRequestDTO
                {
                    LeaveId = leaveRequest.LeaveId,
                    EmployeeId = leaveRequest.EmployeeId,
                    ManagerId = leaveRequest.ManagerId,
                    LeaveType = leaveRequest.LeaveType,
                    LeaveStartDate = leaveRequest.LeaveStartDate,
                    LeaveEndDate = leaveRequest.LeaveEndDate,
                    HoursTaken = leaveRequest.HoursTaken,
                    Status = leaveRequest.Status,
                    IsApproved = leaveRequest.IsApproved

                });
            }
            return leaveRequestDTOs;
        }

        public LeaveRequestDTO GetLeaveById(int LeaveId)
        {
            var leaveRequest = _context.LeaveRequests.Find(LeaveId);
            if (leaveRequest == null)
            {
                throw new Exception("Leave request not found");
            }
            return new LeaveRequestDTO
            {
                LeaveId = leaveRequest.LeaveId,
                EmployeeId = leaveRequest.EmployeeId,
                ManagerId = leaveRequest.ManagerId,
                LeaveType = leaveRequest.LeaveType,
                LeaveStartDate = leaveRequest.LeaveStartDate,
                LeaveEndDate = leaveRequest.LeaveEndDate,
                HoursTaken = leaveRequest.HoursTaken,
                Status = leaveRequest.Status,
                IsApproved = leaveRequest.IsApproved
            };
        }

        public LeaveRequest CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO)
        {
            if (leaveRequestDTO == null)
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
                    Status = leaveRequestDTO.Status,
                    IsApproved = leaveRequestDTO.IsApproved
                };
                _context.LeaveRequests.Add(leaveRequest);
                _context.SaveChanges();
                return leaveRequest;
            }
            else
            {
                throw new Exception("Leave request cannot be null");
            }
        }
        public void UpdateLeaveRequest(int leaveId, LeaveRequestDTO leaveRequestDTO)
        {
            var leaveRequest = _context.LeaveRequests.Find(leaveId);
            if (leaveRequest == null)
            {
                throw new Exception("Leave request not found");
            }
            leaveRequest.LeaveId = leaveRequestDTO.LeaveId;
            leaveRequest.EmployeeId = leaveRequestDTO.EmployeeId;
            leaveRequest.ManagerId = leaveRequestDTO.ManagerId;
            leaveRequest.LeaveType = leaveRequestDTO.LeaveType;
            leaveRequest.LeaveStartDate = leaveRequestDTO.LeaveStartDate;
            leaveRequest.LeaveEndDate = leaveRequestDTO.LeaveEndDate;
            leaveRequest.HoursTaken = leaveRequestDTO.HoursTaken;
            leaveRequest.Status = leaveRequestDTO.Status;
            leaveRequest.IsApproved = leaveRequestDTO.IsApproved;

            _context.LeaveRequests.Update(leaveRequest);
            _context.SaveChanges();
        }

        public void DeleteLeaveRequest(int LeaveId)
        {
            var leaveRequest = _context.LeaveRequests.FirstOrDefault(g => g.LeaveId == LeaveId);
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




    }
}
