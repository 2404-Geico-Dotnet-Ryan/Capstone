using Capstone.DTOs;


namespace Capstone.Services
{
    public interface IManagerService
    {
        List<ManagerDTO> GetManagers();
        ManagerDTO GetManager(int id);
        ManagerDTO AddManager(ManagerDTO managerDTO);
        ManagerDTO UpdateManager(int id, ManagerDTO managerDTO);
        void DeleteManager(int id);

    }
}