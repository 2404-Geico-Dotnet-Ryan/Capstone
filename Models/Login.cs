namespace Capstone.Models
{
    public class Login
    {
        public int LoginId { get; set; }
        public int EmployeeId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        
        // This establishes the "one to one" relationship 
        // One Login to One Employee  
        public Employee Employee { get; set; }

        /* NO Argurments Constructor*/
        public Login()
        {

        }

        /* FULL Argurments Constructor */
        public Login(int loginId, int employeeId, string userName, string password)
        {
            LoginId = loginId;
            EmployeeId = employeeId;
            UserName = userName;
            Password = password;
        }
    }
}
