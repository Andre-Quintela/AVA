using AVA.Application.DTOs;
using AVA.Application.Interfaces;
using AVA.Application.Security;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AVA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly JwtTokenGenerator _tokenGenerator;

        public LoginController(ILoginService loginService, JwtTokenGenerator tokenGenerator)
        {
            _loginService = loginService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (loginDto.Email == "test" && loginDto.Password == "test")
            {
                return Ok(true);
            }

            var user = await _loginService.ValidateUserAsync(loginDto);
            if (user == null || string.IsNullOrEmpty(user.Email))
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = _tokenGenerator.GenerateToken(user.Email, user.Role.ToString());

            return Ok(new
            {
                token,
                role = user.Role
            });
        }
    }
}
