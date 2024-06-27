using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;
using Capstone.Services;

namespace Capstone.Services
{
    public class HolidayService : IHolidayService
    {
        private readonly AppDbContext _context;

        public HolidayService(AppDbContext context)
        {
            _context = context;
        }

        //Get All Holidays for table display
        public List<HolidayDTO> GetHolidays()
        {
            return _context.Holidays.Select(h => new HolidayDTO
            {
                HolidayName = h.HolidayName,
                HolidayYear = h.HolidayYear,
                HolidayDate = h.HolidayDate
            }).ToList();
        }
    }
}