using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string username, string password)
        {
            // static user
            if (username != "test" ||password != "test")
            {
                return Unauthorized();
            }

            // user claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name , username),
                new Claim (ClaimTypes.Role , "Admin")
            };

            // signing credentials
            var signingKey = "MySigningKeyForSha256Security";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var JwtSecurityToken = new JwtSecurityToken(
                issuer:"https://www.mikro.com.tr",
                audience:"MyAudienceValue",
                claims:claims,
                expires:DateTime.Now.AddDays(15),
                notBefore:DateTime.Now,
                signingCredentials: credentials
            );


            var token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);


            return Content(token);
        }
    }
}
