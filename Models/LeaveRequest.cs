namespace Capstone.Models
{
    public class LeaveRequest
    {
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string? LeaveType { get; set; }
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public int HoursTaken { get; set; }
        public bool IsApproved { get; set; }

        // This establishes the "one to one" relationship 
        // One LeaveRequest to One Employee  
        public Employee Employee { get; set; }
        
        /* NO Argurments Constructor*/
        public LeaveRequest()
        {

        }

        /* FULL Argurments Constructor */
        public LeaveRequest(int leaveId , int employeeId, int managerId, string leaveType, DateTime leaveStartDate, 
                            DateTime leaveEndDate , int hoursTaken, bool isApproved)
        {
            LeaveId = leaveId;
            EmployeeId = employeeId;
            ManagerId = managerId;
            LeaveType = leaveType;
            LeaveStartDate = leaveStartDate;
            LeaveEndDate = leaveEndDate;
            HoursTaken = hoursTaken;
            IsApproved = isApproved;
        }
    }
}