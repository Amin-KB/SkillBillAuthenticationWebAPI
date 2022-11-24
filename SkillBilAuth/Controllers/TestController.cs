using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SkillBilAuth.ResponseAndRequest;
using SkillBilAuth.Services;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SkillBilAuth.Entities;
using System.Security.Claims;

namespace SkillBilAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {

        [HttpGet]
        [Route("test")]
        public IActionResult Testing(string email)
        {
            SkillBilAuth.Services.FetchService.CreateTheConnection();
            string result = SkillBilAuth.Services.FetchService.Search(email);

            return Ok(result);
        }
        [HttpPost]
        [Route("test2")]
        public IActionResult Testing([FromForm] string email, [FromForm] string pass)
        {
            var request = new UserAuthenticationRequest(email, pass);
            if (!AspNetUserService.AuthenticateUserFromDB(request))
                return BadRequest(request);
            var response = AspNetUserService.GetUserFromDB(request);
            return Ok(response);



        }
    }
}
