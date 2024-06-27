using Capstone.DTOs;

namespace Capstone.Services
{
    public interface IHolidayService
    {
        List<HolidayDTO> GetHolidays();
        
    }
}