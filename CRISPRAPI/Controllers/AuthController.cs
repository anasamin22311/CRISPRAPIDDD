using Application.Services.Interfaces;
using Domain.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CRISPRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid model state", Errors = ModelState.Values.SelectMany(v => v.Errors) });
            }
            var result= await _authService.RegisterAsync(model);
            if(!result.IsAuthenticated) 
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid model state", Errors = ModelState.Values.SelectMany(v => v.Errors) });
            }
            var result = await _authService.LoginAsync(model);
            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRole model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid model state", Errors = ModelState.Values.SelectMany(v => v.Errors) });
            }
            var result = await _authService.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);
            return Ok(model);

        }
    }
}
