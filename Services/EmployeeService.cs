using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;

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
                PtoLeaveHours = e.PtoLeaveHours,
                ReqPtoLeaveHours = e.ReqPtoLeaveHours,
                FloatingHolidayHours = e.FloatingHolidayHours,
                ReqFloatingHolidayHours = e.ReqFloatingHolidayHours,
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
                PtoLeaveHours = employee.PtoLeaveHours,
                ReqPtoLeaveHours = employee.ReqPtoLeaveHours,
                FloatingHolidayHours = employee.FloatingHolidayHours,
                ReqFloatingHolidayHours = employee.ReqFloatingHolidayHours,
                IsManager = employee.IsManager,
                IsAdmin = employee.IsAdmin
            };
        }

        //Add Employee
        public EmployeeDTO AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                ManagerId = employeeDTO.ManagerId,
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Birthday = employeeDTO.Birthday,
                HireDate = employeeDTO.HireDate,
                PhoneNumber = employeeDTO.PhoneNumber,
                AddressLine1 = employeeDTO.AddressLine1,
                City = employeeDTO.City,
                State = employeeDTO.State,
                ZipCode = employeeDTO.ZipCode,
                Email = employeeDTO.Email,
                PtoLeaveHours = employeeDTO.PtoLeaveHours,
                ReqPtoLeaveHours = employeeDTO.ReqPtoLeaveHours,
                FloatingHolidayHours = employeeDTO.FloatingHolidayHours,
                ReqFloatingHolidayHours = employeeDTO.ReqFloatingHolidayHours,
                IsManager = employeeDTO.IsManager,
                IsAdmin = employeeDTO.IsAdmin
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
            employeeDTO.EmployeeId = employee.EmployeeId;
            return employeeDTO;
        }

        //Update Employee
        public EmployeeDTO UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
                employee.ManagerId = employeeDTO.ManagerId;
                employee.FirstName = employeeDTO.FirstName;
                employee.LastName = employeeDTO.LastName;
                employee.Birthday = employeeDTO.Birthday;
                employee.HireDate = employeeDTO.HireDate;
                employee.PhoneNumber = employeeDTO.PhoneNumber;
                employee.AddressLine1 = employeeDTO.AddressLine1;
                employee.City = employeeDTO.City;
                employee.State = employeeDTO.State;
                employee.ZipCode = employeeDTO.ZipCode;
                employee.Email = employeeDTO.Email;
                employee.PtoLeaveHours = employeeDTO.PtoLeaveHours;
                employee.ReqPtoLeaveHours = employeeDTO.ReqPtoLeaveHours;
                employee.FloatingHolidayHours = employeeDTO.FloatingHolidayHours;
                employee.ReqFloatingHolidayHours = employeeDTO.ReqFloatingHolidayHours;
                employee.IsManager = employeeDTO.IsManager;
                employee.IsAdmin = employeeDTO.IsAdmin;
                _context.SaveChanges();
                return employeeDTO;
        }

        //Delete Employee
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

    }
}