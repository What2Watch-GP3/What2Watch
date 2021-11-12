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

        public MovieController(IMovieDataAccess movieDataAccess)
        {
            _movieDataAccess = movieDataAccess;

        }
        // GET: api/<MovieController>
        [HttpGet]
        public async Task <ActionResult<IEnumerable<MovieDto>>> GetAllAsync()
        {
            return Ok();


        }
        /*

        // GET: api/<MovieController>
        [HttpGet("{searchString}")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetListByPartOfNameAsync()
        {



        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetByIdAsync(int id)
        {
            return null;
        }



        /* POST api/<MovieController>
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync([FromBody] MovieDto movie)
        {
            

        

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] MovieDto movie)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
        }*/
    }
}
