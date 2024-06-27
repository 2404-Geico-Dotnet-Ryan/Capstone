using Microsoft.AspNetCore.Mvc;
using Capstone.DTOs;
using Capstone.Data;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidayController : ControllerBase
    {
     private readonly AppDbContext _context;

    public HolidayController(AppDbContext context)
        {
            _context = context;
        }

    [HttpGet]
        public ActionResult<List<HolidayDTO>> GetHolidays()
        { var holidays = _context.Holidays.Select(h => new HolidayDTO
            {
                HolidayName = h.HolidayName,
                HolidayYear = h.HolidayYear,
                HolidayDate = h.HolidayDate
                
            }).ToList();
            return holidays;
        }
    }
}