namespace Capstone.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string? Department { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        // This establishes the "one to many" relationship 
        // One Manager to Many Employees 
        //public ICollection<Employee> Employees { get; set; } 7/1
        public ICollection<Employee> Reports { get; set; } //7/1
        public Employee Employee { get; set;}  //7/1


        /* NO Argurments Constructor*/
        public Manager()
        {

        }

        /* FULL Argurments Constructor */
        public Manager(int managerId, string department, string firstName, string lastName, string email)
        {
            ManagerId = managerId;
            Department = department;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}