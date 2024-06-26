namespace Capstone.DTOs
{
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
}