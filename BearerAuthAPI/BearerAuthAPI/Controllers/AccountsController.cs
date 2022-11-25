using BearerAuthAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BearerAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (userLoginModel.UserName == "admin" && userLoginModel.Password == "admin")
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email,"admin@admin.com"),
                    new Claim(JwtRegisteredClaimNames.Name,"adminOfTheSystem"),

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bu gizli bir cumledir"));
                var cryptoCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                       issuer: "identity.aktifbank.com",
                       audience: "client.aktifank.com",
                       claims: claims,
                       notBefore: DateTime.Now,
                       expires: DateTime.Now.AddMinutes(30),
                       signingCredentials: cryptoCredential
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest();
        }
    }
}
