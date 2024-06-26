using Capstone.Data;
using Capstone.DTOs;

namespace Capstone.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        //Get Employee
        public List<EmployeeDTO> GetEmployees()
        {
            return _context.Employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                ManagerId = e.ManagerId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Birthday = e.Birthday,
                HireDate = e.HireDate,
                PhoneNumber = e.PhoneNumber,
                AddressLine1 = e.AddressLine1,
                City = e.City,
                State = e.State,
                ZipCode = e.ZipCode,
                Email = e.Email,
                IsManager = e.IsManager,
                IsAdmin = e.IsAdmin
            }).ToList();
        }

        //Get Employee by ID
        public EmployeeDTO GetEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                ManagerId = employee.ManagerId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Birthday = employee.Birthday,
                HireDate = employee.HireDate,
                PhoneNumber = employee.PhoneNumber,
                AddressLine1 = employee.AddressLine1,
                City = employee.City,
                State = employee.State,
                ZipCode = employee.ZipCode,
                Email = employee.Email,
                IsManager = employee.IsManager,
                IsAdmin = employee.IsAdmin
            };
        }

    }
}