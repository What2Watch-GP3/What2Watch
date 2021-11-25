using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebSite.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private IWhatToWatchApiClient _webApiClient;
        private const double EXPIRY_DURATION_MINUTES = 30;
        private string _generatedToken = null;
        private IConfiguration _config;

        public LoginController(IConfiguration config, IWhatToWatchApiClient whatToWatchApi)
        {
            _config = config;
            _webApiClient = whatToWatchApi;
        }
        // GET: LoginController
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // POST: LoginController/Create
        //TODO: check if we need all these attributes
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] UserDto loginInfo, [FromQuery] string returnUrl)
        {

            UserDto userDto = await _webApiClient.LoginAsync(loginInfo);

            if (userDto.Id == -1)
            {
                ViewBag.ErrorMessage = "Wrong User email or Password";
            }
            else
            {
                _generatedToken = BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), _config["Jwt:Audience"].ToString(), userDto);
                if (_generatedToken != null)
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //TODO: consider changing the "error" to smth more descriptive
                    ViewBag.ErrorMessage = "Error logging in";
                }
            }
            return View();
        }

        //TODO: export these methods to an external static class for JWT handling.
        public string BuildToken(string key, string issuer, string audience, UserDto user)
        {
            //TODO: add roles
            var claims = new[] {
                new Claim("user_id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                //new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, audience, claims,
                expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

        public bool IsTokenValid(string key, string issuer, string token)
        {
            var mySecret = Encoding.UTF8.GetBytes(key);
            var mySecurityKey = new SymmetricSecurityKey(mySecret);
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                //TODO: implement checking Issuer and Audience
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = mySecurityKey,
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
