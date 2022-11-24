using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillBilAuth.ResponseAndRequest;
using SkillBilAuth.Services;

namespace SkillBilAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserAuthenticationRequest userAuthenticationRequest)
        {
            
            if (!AspNetUserService.AuthenticateUserFromDB(userAuthenticationRequest))
                return BadRequest(userAuthenticationRequest);
            var response = AspNetUserService.GetUserFromDB(userAuthenticationRequest);
            return Ok(response);
        }
    }
}
