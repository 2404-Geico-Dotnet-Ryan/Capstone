using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;

namespace Capstone.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly AppDbContext _context;

        //Constructor to inject the AppDbContext
        public LeaveTypeService(AppDbContext context)
        {
            _context = context;
        }

        // Method to Create a new LeaveType
        public LeaveType CreateLeaveType(LeaveTypeDTO leaveTypeDTO)
        {
            if (ValidateNewLeaveTypeDTO(leaveTypeDTO))
            {
                var newLeaveType = new LeaveType
                {
                    LeaveTypeName = leaveTypeDTO.LeaveTypeName,
                    IsPaid = leaveTypeDTO.IsPaid
                };
                _context.LeaveTypes.Add(newLeaveType);
                _context.SaveChanges();
                return newLeaveType;
            }
            else
            {
                
                 throw new Exception("Invalid leave type");
            }
        }
        
        //Private method to validate the new LeaveType
           private bool ValidateNewLeaveTypeDTO(LeaveTypeDTO LeaveTypeDto)
        {
            return !string.IsNullOrWhiteSpace(LeaveTypeDto.LeaveTypeName);
        }

        // Method to Delete a LeaveType base on the ID
        public void DeleteLeaveType(int LeaveTypeId)
        {
            var leaveType = _context.LeaveTypes.FirstOrDefault(lt => lt.LeaveTypeId == LeaveTypeId);
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

        // Method to get a list of all LeaveTypes
        public IEnumerable<LeaveTypeDTO> GetAllLeaveTypes()
        {
            var leaveTypes = _context.LeaveTypes
            .Select(lt => new LeaveTypeDTO
            {
                LeaveTypeId = lt.LeaveTypeId,
                LeaveTypeName = lt.LeaveTypeName,
                IsPaid = lt.IsPaid
            }).ToList();
            
            
            return leaveTypes;
            
        }

        // Method to get a specific LeaveType by the ID
        public LeaveTypeDTO GetLeaveTypeById(int LeaveTypeId)
        {
            var leaveType = _context.LeaveTypes.Find(LeaveTypeId);
            if (leaveType != null)
            {
                var leaveTypeDTO = new LeaveTypeDTO
                {
                    LeaveTypeId = leaveType.LeaveTypeId,
                    LeaveTypeName = leaveType.LeaveTypeName,
                    IsPaid = leaveType.IsPaid
                };
                return leaveTypeDTO;
            }
                else
            {
                throw new Exception("Leave type not found");
            }
        }

        //Method to update an existing LeaveType based on the ID
        public void UpdatedLeaveType(int LeaveTypeId, LeaveTypeDTO UpdatedLeaveType)
        {
           
            var leaveType = _context.LeaveTypes.Find(LeaveTypeId);
            if (leaveType != null)
            {
                leaveType.LeaveTypeName = UpdatedLeaveType.LeaveTypeName;
                leaveType.IsPaid = UpdatedLeaveType.IsPaid;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Leave type not found");
            }
        }
    
    }
}