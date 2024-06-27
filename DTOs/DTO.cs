using System.Data;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Capstone.DTOs
{
    public class PerformanceDTO
    {
        public int PerformanceId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string? ReviewPeriod { get; set; }
        public string? Achievements { get; set; }
        public string? ImprovementAreas { get; set; }
        public int TotalReviewScore { get; set; }
        public bool IsCompletedPA { get; set; }
        public bool IsCompletedReview { get; set; }
        public ICollection<GoalsDTO>? Goals { get; set; }
    }

    public class GoalsDTO
    {
        public int GoalId { get; set; }
        public int PerformanceId { get; set; }
        public string? Goal { get; set; }
        public string? Deliverable { get; set; }
        public DateTime Deadline { get; set; }
        public int Weightage { get; set; }
        public int GoalScore { get; set; }
        public string? ManagerFeedback { get; set; }

    }


    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime HireDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AddressLine1 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Email { get; set; }
        public int PtoLeaveHours { get; set; }
        public int ReqPtoLeaveHours { get; set; }
        public int FloatingHolidayHours { get; set; }
        public int ReqFloatingHolidayHours { get; set; }
        public bool IsManager { get; set; }
        public bool IsAdmin { get; set; }
    }

    public class LoginDTO
    {
        public int? LoginId { get; set; }
        public int EmployeeId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        
    }

    public class LeaveRequestDTO
    {
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string? LeaveType { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public int HoursTaken { get; set; }
        public string? Status { get; set; }
        public bool IsApproved { get; set; }
    }

    public class LeaveTypeDTO
    {
        public int LeaveTypeId { get; set; }
        public string? LeaveTypeName { get; set; }
        public bool IsPaid { get; set; }
    }
     public class HolidayDTO
    {
         public int HolidayId { get; set; }
        public string? HolidayName { get; set; }
        public string? HolidayYear { get; set; }
        public string? HolidayDate { get; set; }
    }

    public class ManagerDTO
    {
       public int ManagerId { get; set; }
        public string? Department { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
      
    }

}