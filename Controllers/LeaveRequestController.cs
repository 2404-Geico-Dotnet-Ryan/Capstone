
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
        private readonly ILeaveRequestService _leaveRequstService;

        public LeaveRequestController(ILeaveRequestService leaveRequstService)
        {
            _leaveRequstService = leaveRequstService;
        }

        [HttpPost]
        public ActionResult<LeaveRequestDTO> CreateLeaveRequest(LeaveRequestDTO leaveRequestDTO)
        {
            try
            {
                var leaveRequest = _leaveRequstService.CreateLeaveRequest(leaveRequestDTO);
                return Ok (leaveRequest);
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpDelete("{leaveId}")]
        public ActionResult DeleteLeaveRequest(int leaveId)
        {
            try {
                _leaveRequstService.DeleteLeaveRequest(leaveId);
                return NoContent();
            }
           catch (Exception e)
           {
                if (e.Message == "Leave request not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    throw;
                }
           }
        }

        [HttpGet]
        public ActionResult<IEnumerable<LeaveRequestDTO>> GetLeaveRequests()
        {
            return Ok(_leaveRequstService.GetAllLeave());
        }

        [HttpGet("{leaveId}")]
        public ActionResult<LeaveRequestDTO> GetLeaveRequest(int leaveId)
        {
            try {
                var leaveRequest = _leaveRequstService.GetLeaveById(leaveId);
                return Ok(leaveRequest);
            }
           catch (Exception e)
           {
                if (e.Message == "Leave request not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    throw;
                }
           }
        }

        [HttpPut("{leaveId}")]
        public ActionResult<LeaveRequestDTO> UpdateLeaveRequest(int leaveId, LeaveRequestDTO leaveRequestDTO)
        {
            try
            {
                var leaveRequest = _leaveRequstService.UpdateLeaveRequest(leaveId, leaveRequestDTO);
                return Ok(leaveRequest);
            }
            catch (Exception e)
           {
                if (e.Message == "Leave request not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    throw;
                }
           }

        }

        //URI to send e-mail after Employee request leave
        [HttpPost("Employee/{leaveId}")]
        public async Task<ActionResult> SendLeaveRequestEmail(int leaveId)
        {   
            EmailService.ToManagerLeaveRequestEmailDTO(await _leaveRequstService.BuildLeaveRequestDTO(leaveId));
            return Ok();
        }

        //URI to send e-mail after Manager reviews leave
        [HttpPost("Manager/{leaveId}")]
        public async Task<ActionResult> SendLeaveReviewedEmail(int leaveId)
        {   
            EmailService.ToEmployeeLeaveReviewEmailDTO(await _leaveRequstService.BuildLeaveRequestDTO(leaveId));
            return Ok();
        }
        
    }
}