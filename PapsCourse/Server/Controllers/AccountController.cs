using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PapsCourse.Server.Models;
using PapsCourse.Shared.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PapsCourse.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        public AccountController() 
        {
            
        }

        private List<string> people = new List<string>
        {
            "dscdscdsc",
            "vdvdfvderv"
        };

        public ActionResult Registration(RegistrationRequest registrationRequest) 
        {

            return Ok();
        }

        [HttpPost]
        public ActionResult<string> SetCookies()
        {
            HttpContext.Response.Cookies.Append("da", "rewre");
            return "Hello";
        }

        [HttpGet]
        public ActionResult<string> GetCookies()
        {
            var a = HttpContext.Request.Cookies["da"];

            return a;
        }

        [HttpPost]
        public ActionResult<string> GetJwt()
        {
            return JwtToken.GetToken(new User { Email = "cdcds" });
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }
    }
}
