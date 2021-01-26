using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Impulse.AngularHost.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.IdentityModel.Tokens;

namespace Impulse.AngularHost.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        {
            
        }

        [HttpPost("[action]")]
        public ActionResult Login([FromBody]LoginRequest login)
        {
            byte[] hmacSha256Bytes = Convert.FromBase64String("4DMF95Tck56TrEZkbdcoFAcdVwvsSSQaIuiYxBT5laXdgEJ6JyWVjhJfykhbtnLWVRm2qCaTMZac2gdEs/SG8g==");
            var secretKey = new SymmetricSecurityKey(hmacSha256Bytes);
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "https://localhost:11020",
                audience: "https://localhost:11020",
                claims: new List<Claim>(),
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(50),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                Token = tokenString,
                ExpiresIn = token.ValidTo,
                Username = login.Username
            });
            
            //return Unauthorized();
        }

        [HttpGet]
        public ActionResult Login()
        {
            //HttpContext.Authentication.SignOutAsync()
            return Ok(new {
               Name = "asd",
               Id = "xzc" 
            });
        }

    }
}
