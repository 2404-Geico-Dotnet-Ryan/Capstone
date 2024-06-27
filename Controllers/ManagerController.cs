using Capstone.DTOs;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public ActionResult<List<ManagerDTO>> GetManagers()
        {
            return Ok(_managerService.GetManagers());
        }

        [HttpGet("{id}")]
        public ActionResult<ManagerDTO> GetManager(int id)
        {
            try
            {
                var manager = _managerService.GetManager(id);
                return Ok(manager);
            }
            catch (Exception e)
            {
                if (e.Message == "Manager not found")
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
        public ActionResult<ManagerDTO> AddManager(ManagerDTO managerDTO)
        {
            try
            {
                var manager = _managerService.AddManager(managerDTO);
                
                return Created($"/manager/{manager.ManagerId}", manager);
            }
            catch (Exception e)
            {
                if (e.Message == "Manager already exists")
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
        public ActionResult<ManagerDTO> UpdateManager(int id, ManagerDTO managerDTO)
        {
            try
            {
                var manager = _managerService.UpdateManager(id, managerDTO);
                
                return Ok(manager);
            }
            catch (Exception e)
            {
                if (e.Message == "Manager not found")
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
        public ActionResult DeleteManager(int id)
        {
            try
            {
                _managerService.DeleteManager(id);
                return NoContent();
            }
            catch (Exception e)
            {
                if (e.Message == "Manager not found")
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