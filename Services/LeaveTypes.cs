using Capstone.Data;

namespace Capstone.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly AppDbContext _context;

        public LeaveTypeService(AppDbContext context)
        {
            _context = context;
        }

    }
}