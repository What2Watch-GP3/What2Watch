using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.DTOs;
using DataAccess.Models;
using WebApi.DTOs.Converters;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserDataAccess _userDataAccess;
        private IConfiguration _configuration;

        public LoginController(IConfiguration configuration, IUserDataAccess userDataAccess)
        {
            _configuration = configuration;
            _userDataAccess = userDataAccess;
        }
        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] UserDto userDto)
        {


            var user = DtoConverter<UserDto, User>.From(userDto);
            //Authorize
            userDto.Id = await _userDataAccess.LoginAsync(user);
            if (userDto.Id != -1)
            {
                //Authenticate
                string jwtToken = GenerateToken(userDto);

                Response.Cookies.Append("X-Access-Token", jwtToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                //Response.Cookies.Append("X-Email", user.Email, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });
                //Response.Cookies.Append("X-Refresh-Token", user.RefreshToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict });

                return Ok(userDto.Id);
            }
            else
            {
                return NotFound("User not found");
            }
        }

        [HttpGet("validateToken")]
        //[Route("validateToken")]
        public async Task<ActionResult<bool>> ValidateTokenAsync()
        {
            if (!Request.Cookies.TryGetValue("X-Access-Token", out var token))
            {
                return false;
            }
            var mySecret = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"].ToString(),
                    ValidAudience = _configuration["Jwt:Audience"].ToString(),
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
                var temp = (JwtSecurityToken) validatedToken;

            }
            catch
            {
                return false;
            }
            return true;
        }

        //TODO: export these methods to an external static class for JWT handling.
        private string GenerateToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"].ToString(),
                Audience = _configuration["Jwt:Audience"].ToString(),
                Subject = new ClaimsIdentity(new[] {
                    //new Claim(ClaimTypes.Role, "User"),
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email) }),
                Expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationMinutes"])),
                SigningCredentials = credentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
