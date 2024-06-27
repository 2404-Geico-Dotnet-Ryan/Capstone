
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
    public class LeaveTypeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public LeaveTypeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public LeaveTypeDTO CreateLeaveType(LeaveTypeDTO leaveTypeDTO)
        {
            var leaveType = new LeaveType
            {
                LeaveTypeId = leaveTypeDTO.LeaveTypeId,
                LeaveTypeName = leaveTypeDTO.LeaveTypeName,
                IsPaid = leaveTypeDTO.IsPaid
            };
            _context.LeaveTypes.Add(leaveType);
            _context.SaveChanges();
            return leaveTypeDTO;
        }

        [HttpDelete("{LeaveTypeId}")]
        public void DeleteLeaveType(int LeaveTypeId)
        {
            var leaveType = _context.LeaveTypes.FirstOrDefault(l => l.LeaveTypeId == LeaveTypeId);
            if (leaveType != null)
            {
                _context.LeaveTypes.Remove(leaveType);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Leave type not found");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<LeaveTypeDTO>> GetLeaveType()
        {
            var leaveType = _context.LeaveTypes.Select(l => new LeaveTypeDTO
            {
                LeaveTypeId = l.LeaveTypeId,
                LeaveTypeName = l.LeaveTypeName,
                IsPaid = l.IsPaid
            }).ToList();
            return leaveType;
        }

        [HttpGet("{LeaveTypeId}")]
        public ActionResult<LeaveTypeDTO> GetLeaveType(int LeaveTypeId)
        {
            var leaveType = _context.LeaveTypes.Select(l => new LeaveTypeDTO
            {
                LeaveTypeId = l.LeaveTypeId,
                LeaveTypeName = l.LeaveTypeName,
                IsPaid = l.IsPaid
            }).FirstOrDefault(l => l.LeaveTypeId == LeaveTypeId);
            if (leaveType == null)
            {
                return NotFound();

            }
            return leaveType;
        }
        [HttpPut("{LeaveTypeId}")]
        public ActionResult<LeaveTypeDTO> UpdateLeaveType(int LeaveTypeId, LeaveTypeDTO leaveTypeDTO)
        {
            var leaveType = _context.LeaveTypes.FirstOrDefault(l => l.LeaveTypeId == LeaveTypeId);
            if (leaveTypeDTO == null)
            {
                return NotFound();
            }
                leaveType.LeaveTypeId = leaveTypeDTO.LeaveTypeId;
                leaveType.LeaveTypeName = leaveTypeDTO.LeaveTypeName;
                leaveType.IsPaid = leaveTypeDTO.IsPaid;
            _context.SaveChanges();
            return leaveTypeDTO;

        }
    }
}