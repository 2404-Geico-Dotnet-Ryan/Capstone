using Capstone.DTOs;

namespace Capstone.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int id);
        
    }
}