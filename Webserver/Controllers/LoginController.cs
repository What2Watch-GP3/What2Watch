using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public Task<ActionResult> Login([FromForm] UserDto loginInfo, [FromQuery] string returnUrl)
        {
            if ((String.IsNullOrEmpty(loginInfo.Email))&& (String.IsNullOrEmpty(loginInfo.Password)))
            {

            }    
            return null;
        }
    }
}
