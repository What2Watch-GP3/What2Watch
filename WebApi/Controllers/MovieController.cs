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
    public class MovieController : ControllerBase
    {

        IMovieDataAccess _movieDataAccess;

        public MovieController(IConfiguration configuration)
        {
            _movieDataAccess = new MovieDataAccess(configuration.GetConnectionString("DefaultConnection"));

        }
        // GET: api/<MovieController>
        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {


            return new string[] { "value1", "value2" };
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public string GetByIdAsync(int id)
        {
            return "value";
        }

        // POST api/<MovieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
