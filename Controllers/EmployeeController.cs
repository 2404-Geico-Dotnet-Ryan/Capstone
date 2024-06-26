using Capstone.DTOs;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<EmployeeDTO>> GetEmployees()
        {
            return Ok(_employeeService.GetEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> GetEmployee(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployee(id);
                return Ok(employee);
            }
            catch (Exception e)
            {
                if (e.Message == "Employee not found")
                {
                    return NotFound(e.Message);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}