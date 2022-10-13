using JWTAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JWTAuthentication.Services;

namespace JWTAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(User user)
        {
            return Ok(new 
            { 
                user.Name, 
                user.Email, 
                token = JWTTokenService.CreateToken(user)
            });
        }
    }
}