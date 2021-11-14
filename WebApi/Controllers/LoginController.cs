using DataAccess.DataAccess;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserDataAccess _userDataAccess;
        public LoginController(IConfiguration configuration)
        {
           _userDataAccess = new UserDataAccess(configuration.GetConnectionString("DefaultConnection"));
        }
        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] UserDto values)
        {
           return await _userDataAccess.LoginAsync(values.Email, values.Password);
        }
    }
}
