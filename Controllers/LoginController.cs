using Capstone.DTOs;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LoginDTO>> GetAllLogins()
        {
            var login = _loginService.GetAllLogins();
            return Ok(login);
        }

        [HttpGet("{LoginId}")]
        public ActionResult<LoginDTO> GetLoginById(int LoginId)
        {
            var login = _loginService.GetLoginById(LoginId);
            return login;
        }

        [HttpPost]
        public ActionResult<LoginDTO> PostLogin(LoginDTO loginDto)
        {
            var login = _loginService.CreateLogin(loginDto);
            return CreatedAtAction(nameof(GetLoginById), new { LoginId = login.LoginId}, loginDto);
        }

        [HttpPut("{LoginId}")]
        public ActionResult<LoginDTO> UpdateLogin(int LoginId, LoginDTO updatedLogin)
        {
            _loginService.UpdateLogin(LoginId, updatedLogin);
            return Ok(updatedLogin);
        }

        [HttpDelete("{LoginId}")]
        public IActionResult DeleteLogin(int LoginId)
        {
            _loginService.DeleteLogin(LoginId);
            return Ok();
        }

        // POST: /Users/login
        // Logs in a user
        [HttpPost("login")]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO userLogin)
        {
            var login = await _loginService.LoginUser(userLogin);

            if (login == null)
            {
                return Unauthorized();
            }
            return login;
        }

        //URI to send e-mail after Employee request password be reset
        [HttpPost("{userName}")]
        public async Task<ActionResult> SendPasswordResetEmail(string userName)
        {   
            EmailService.ToResetPasswordEmailDTO(await _loginService.BuildPasswordResetDTO(userName));
            return Ok();
        }
    }
}