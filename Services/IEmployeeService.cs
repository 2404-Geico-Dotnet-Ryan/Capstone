using Capstone.DTOs;

namespace Capstone.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int id);
        EmployeeDTO AddEmployee(EmployeeDTO employeeDTO);
        EmployeeDTO UpdateEmployee(int id, EmployeeDTO employeeDTO);
        void DeleteEmployee(int id);
        
    }
}