using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public LoginController(IWhatToWatchApiClient whatToWatchApi)
        {
            _webApiClient = whatToWatchApi;
        }
        // GET: LoginController
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> LoginAsync([FromQuery] string returnUrl)
        {
            if (await HasValidTokenAsync())
            {
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Movies");
            }
            return View();
        }
        // POST: LoginController/Create
        //TODO: check if we need all these attributes
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] UserDto loginInfo, string returnUrl="")
        {

            String token = await _webApiClient.LoginAsync(loginInfo);
            if (!String.IsNullOrEmpty(token))
            {
                //Currently the token is saved in the webApi which is a singleton - future improvement. Develop a IRestClient middleware to make it work.
                //HttpContext.Session.SetString("JWTToken", token);
                _webApiClient.JWTToken = token;
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Movies");
            }

            TempData["ErrorMessage"] = "Wrong User email or Password";
            return View();
            /*
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
                    return RedirectToAction("Index", "Movies");
                }
                else
                {
                    //TODO: consider changing the "error" to smth more descriptive
                    ViewBag.ErrorMessage = "Error logging in";
                }
            }
            */
        }
        private async Task<bool> HasValidTokenAsync()
        {

            return await _webApiClient.HasValidToken();
        }
    }
}
