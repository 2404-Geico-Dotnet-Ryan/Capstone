using Capstone.Controllers;
using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;

namespace Capstone.Services
{
    public class ManagerService : IManagerService
    {
        private readonly AppDbContext _context;

        public ManagerService(AppDbContext context)
        {
            _context = context;
        }

        //Get Manager
        public List<ManagerDTO> GetManagers()
        {
            return _context.Managers.Select(m => new ManagerDTO
            {
                ManagerId = m.ManagerId,
                Department = m.Department,
                FirstName = m.FirstName,
                LastName = m.LastName,
                
            }).ToList();
        }

        //Get Manager by ID
        public ManagerDTO GetManager(int id)
        {
            var manager = _context.Managers.Find(id);
            if (manager == null)
            {
                throw new Exception("Manager not found");
            }
            return new ManagerDTO
            {
               ManagerId = manager.ManagerId,
                Department = manager.Department,
                FirstName = manager.FirstName,
                LastName = manager.LastName,
            };
        }

        //Add Manager
        public ManagerDTO AddManager(ManagerDTO managerDTO)
        {
            var manager = new Manager
            {
               ManagerId = managerDTO.ManagerId,
                Department =managerDTO.Department,
                FirstName = managerDTO.FirstName,
                LastName = managerDTO.LastName,
            };
            _context.Managers.Add(manager);
            _context.SaveChanges();
            managerDTO.ManagerId = manager.ManagerId;
            return managerDTO;
        }

        //Update Manager
        public ManagerDTO UpdateManager(int id, ManagerDTO managerDTO)
        {
            var manager = _context.Managers.Find(id);
            if (manager == null)
            {
                throw new Exception("Manager not found");
            }
                manager.ManagerId = managerDTO.ManagerId;
                manager.Department =managerDTO.Department;
                manager.FirstName = managerDTO.FirstName;
                manager.LastName = managerDTO.LastName;
                
                _context.SaveChanges();
                return managerDTO;
        }

        //Delete Manager
        public void DeleteManager(int id)
        {
            var manager = _context.Managers.Find(id);
            if (manager == null)
            {
                throw new Exception("Manager not found");
            }
            _context.Managers.Remove(manager);
            _context.SaveChanges();
        }

    }
}