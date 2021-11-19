using DataAccess.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        ICinemaDataAccess _cinemaDataAccess;

        public CinemasController(ICinemaDataAccess cinemaDataAccess)
        {
            _cinemaDataAccess = cinemaDataAccess;
        }


        // GET: api/<CinemaController>
        [HttpGet("{movieId}")]
        public async Task<ActionResult<IEnumerable<CinemaDto>>> GetListByMovieIdAsync(int movieId)
        {
            var cinemas = await _cinemaDataAccess.GetListByMovieIdAsync(movieId);
            var cinemaDtos = DtoConverter<Cinema, CinemaDto>.FromList(cinemas);
            return Ok(cinemaDtos);
        }

        /*
        // GET api/<CinemaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CinemaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CinemaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CinemaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
