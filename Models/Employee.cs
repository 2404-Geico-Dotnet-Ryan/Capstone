namespace Capstone.Models
{
    public class Employee
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
        
        // This establishes the "one to one" relationship 
        // One Employee to One Login  
        public Login Login { get; set; }

        // This establishes the "one to one" relationship 
        // One Employee to One Manager  
        public Manager Manager { get; set; }

        // This establishes the "one to many" relationship 
        // One Employee to Many LeaveRequest
        public ICollection<LeaveRequest> LeaveRequests { get; set; }

        // This establishes the "one to many" relationship 
        // One Employee to Many Performance
        public ICollection<Performance> Performances { get; set; }

        /* NO Argurments Constructor*/
        public Employee()
        {

        }

        /* FULL Argurments Constructor */
        public Employee(int employeeId, int managerId,  string firstName, string lastName, DateTime birthday, 
                        DateTime hireDate, string phoneNumber, string addressLine1, string city, string state, string zipCode, 
                        string email, int ptoLeaveHours, 
                        int reqPtoLeaveHours, int floatingHolidayHours, int reqFloatingHolidayHours,
                        bool isManager, bool isAdmin)
        {
            EmployeeId = employeeId;
            ManagerId = managerId;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            HireDate = hireDate;
            PhoneNumber = phoneNumber;
            AddressLine1 = addressLine1;
            City = city;
            State = state;
            ZipCode = zipCode;
            Email= email;
            PtoLeaveHours = ptoLeaveHours;
            ReqPtoLeaveHours= reqPtoLeaveHours;
            FloatingHolidayHours = floatingHolidayHours;
            ReqFloatingHolidayHours = reqFloatingHolidayHours;
            IsManager = isManager;
            IsAdmin = isAdmin;
        }
    }
}
