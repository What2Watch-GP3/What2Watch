using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebSite.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IWebApiClient _webApiClient;

        public UsersController(IWebApiClient whatToWatchApi)
        {
            _webApiClient = whatToWatchApi;
        }
        // GET: LoginController
        [AllowAnonymous]
        [HttpGet("Login")]
        public async Task<ActionResult> Login([FromQuery] string returnUrl)
        {
            if (await HasValidTokenAsync())
            {
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "");
            }
            return View();
        }
        // POST: LoginController/Create
        //TODO: check if we need all these attributes
        [AllowAnonymous]
        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] UserDto loginInfo, string returnUrl="")
        {

            var userDto = await _webApiClient.LoginAsync(loginInfo);

            if (userDto != null)
            {

                //HttpContext.Response.Cookies.Append("X-Access-Token", userDto.Password, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Expires = DateTime.Now.AddMinutes(15) });
                //userDto.Password = null;
                HttpContext.Session.SetString("userData", JsonConvert.SerializeObject(userDto));

                //building clams and properties for signing in with cookies authentication
                //WebApi returns JwtToken inside password field
                var claims = new List<Claim>
                {
                    new Claim("user-id", userDto.Id.ToString()),
                    new Claim(ClaimTypes.Email, userDto.Email),
                    new Claim(ClaimTypes.Name, userDto.Name),
                    new Claim(ClaimTypes.Role, userDto.Role.ToString()),
                    //Jwt token stored in password from response
                    new Claim("access-token", userDto.Password)

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(15),
                    IsPersistent = true
                };


                //performing authentication for client
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


                //depending on with there were any return urls, redirect or go back to home.
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Movies");
            }

            //show an eror message in case no use was found
            TempData["ErrorMessage"] = "Wrong User email or Password";
            return View();
        }


        //[Route("[controller]/Logout")]
        [Route("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            _webApiClient.Logout();
            HttpContext.Response.Cookies.Delete("X-Access-Token");
            return RedirectToAction("Index", "Movies");
        }
        private async Task<bool> HasValidTokenAsync()
        {
            return await _webApiClient.HasValidToken();
        }
    }
}
