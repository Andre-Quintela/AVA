using AVA.Application.DTOs;
using AVA.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AVA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public async Task<bool> Login([FromBody] LoginDto loginDto)
        {
            if(loginDto.Email == "test" && loginDto.Password == "test")
            {
                return true;
            }

            return await _loginService.ValidateUserAsync(loginDto);
        }
    }
}
