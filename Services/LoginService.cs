using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public Login CreateLogin(LoginDTO loginDto)
        {
            if (ValidateNewLogin(loginDto))
            {
                var login = new Login
                {
                    UserName = loginDto.UserName,
                    Password = loginDto.Password,
                    EmployeeId = loginDto.EmployeeId,
                };
                _context.Logins.Add(login);
                _context.SaveChanges();

                return login;
            }
            else
            {
                throw new Exception("Invalid User");
            }
        }

        private bool ValidateNewLogin(LoginDTO loginDto)
        {
            if (loginDto.UserName.Trim().Length == 0)
            {
                return false;
            }
            return true;
        }

        public void DeleteLogin(int LoginId)
        {
            try
            {

                var login = _context.Logins.FirstOrDefault(l => l.LoginId == LoginId);
                if (login == null)
                {
                    throw new Exception($" Login with ID {LoginId} not found");
                }

                _context.Logins.Remove(login);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"An error occured while deleting the login: {ex.Message}");

                throw new Exception("An error occured while deleting the login. Please try again later.", ex);
            }
        }

        public IEnumerable<LoginDTO> GetAllLogins()
        {
            var logins = _context.Logins
                    .Select(l => new LoginDTO
                    {
                        LoginId = l.LoginId,
                        UserName = l.UserName,
                        Password = HidePassword(l.Password),
                        EmployeeId = l.EmployeeId
                    }).ToList();

            return logins;
        }

        public static string HidePassword(string password)
        {
            Random encrypt = new Random();
            string letters = "************ABCDE12345";
            string hidePassWord = "";

            for (int i = 0; i <= 8; i++)
            {
                int pick = encrypt.Next(letters.Length);
                hidePassWord += letters[pick];
            }
            return hidePassWord;
        }

        public LoginDTO GetLoginById(int LoginId)
        {
            var login = _context.Logins.Find(LoginId);
            var loginDto = new LoginDTO
            {
                UserName = login.UserName,
                Password = login.Password,
                EmployeeId = login.EmployeeId
            };

            return loginDto;
        }

        public async Task<ActionResult<LoginDTO>> LoginUser(LoginDTO userLogin)
        {
            // Find the user by username and password
            var login = await _context.Logins.FirstOrDefaultAsync(l => l.UserName == userLogin.UserName && l.Password == userLogin.Password);

            if (login == null)
            {
                return null; // Indicate failure to find the user
            }

            var loginDto = new LoginDTO
            {
                UserName = login.UserName,
                Password = login.Password,
                EmployeeId = login.EmployeeId,

            };

            return loginDto;
        }

        public void UpdateLogin(int LoginId, LoginDTO updatedLogin)
        {
            var login = _context.Logins.FirstOrDefault(l => l.LoginId == LoginId);
            login.UserName = updatedLogin.UserName;
            login.Password = updatedLogin.Password;

            _context.Logins.Update(login);
            _context.SaveChanges();
        }

     public async Task<LeaveEmailDTO> BuildPasswordResetDTO(string userName)
        {   
            // Build new LeaveEmailDTO object
            LeaveEmailDTO emailData = new();

            // Read tables to gather data needed to send out an email
            Login loginData = await _context.Logins.FirstAsync(l => l.UserName == userName);
            Employee employeeData = await _context.Employees.FirstAsync(e => e.EmployeeId == loginData.EmployeeId);
            
            // Add data into the LeaveEmailDTO so it can be sent back and used to send out email
            emailData.EmployeeFirstName = employeeData.FirstName;
            emailData.EmployeeLastName = employeeData.LastName;
            emailData.EmployeeEmail = employeeData.Email;

            return emailData;
        }
    }
}