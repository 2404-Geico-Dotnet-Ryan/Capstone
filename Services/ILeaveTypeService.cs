using Capstone.DTOs;
using Capstone.Models;

namespace Capstone.Services
{
    public interface ILeaveTypeService
    {

        // Method to get a list of all leave types
        IEnumerable<LeaveTypeDTO> GetAllLeaveTypes();

        // Method to get a specific leave type by the ID
        LeaveTypeDTO GetLeaveTypeById(int LeaveTypeId);

        // Method to create a new leave type
        LeaveType CreateLeaveType(LeaveTypeDTO LeaveTypeDto);

        // Method to update an existing leave type based on the ID and the provided updated LeaveTypeDto
        void UpdatedLeaveType(int LeaveTypeId, LeaveTypeDTO UpdatedLeaveType);

        // Method to delete a leave type based on the ID
        void DeleteLeaveType(int LeaveTypeId);
    }
}