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

        [HttpPost]
        public ActionResult<EmployeeDTO> AddEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = _employeeService.AddEmployee(employeeDTO);
                
                return Created($"/employee/{employee.EmployeeId}", employee);
            }
            catch (Exception e)
            {
                if (e.Message == "Employee already exists")
                {
                    return Conflict(e.Message);
                }
                else
                {
                    throw;
                }
            }

        }

        [HttpPut("{id}")]
        public ActionResult<EmployeeDTO> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = _employeeService.UpdateEmployee(id, employeeDTO);
                
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

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return NoContent();
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