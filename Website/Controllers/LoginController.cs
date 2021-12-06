using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebSite.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private IWebApiClient _webApiClient;

        public LoginController(IWebApiClient whatToWatchApi)
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

            loginInfo.Id = await _webApiClient.LoginAsync(loginInfo);
            if (loginInfo.Id > 0)
            {
                //TODO: do smth with user data in order to display it.
                TempData["UserEmail"] = loginInfo.Email;
                if (!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Movies");
            }

            TempData["ErrorMessage"] = "Wrong User email or Password";
            return View();
        }
        private async Task<bool> HasValidTokenAsync()
        {
            return await _webApiClient.HasValidToken();
        }
    }
}
