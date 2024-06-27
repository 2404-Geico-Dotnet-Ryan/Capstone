using Capstone.Data;
using Capstone.DTOs;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public Login CreateLogin(LoginDTO loginDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteLogin(int LoginId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoginDTO> GetAllLogins()
        {
            throw new NotImplementedException();
        }

        public LoginDTO GetLoginById(int LoginId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<LoginDTO>> LoginUser(LoginDTO userLogin)
        {
            throw new NotImplementedException();
        }

        public void UpdateLogin(int LoginId, LoginDTO updatedLogin)
        {
            throw new NotImplementedException();
        }
    }
}