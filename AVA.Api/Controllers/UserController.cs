using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AVA.Api.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet("GetAll")]
        public Task<IActionResult> GetAll()
        {
            return Task.FromResult<IActionResult>(Ok("TEST"));
        }
    }
}
