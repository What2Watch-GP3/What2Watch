using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CinemaDto>>> GetListByMovieIdAsync([FromQuery] int movieId)
        {
            if (movieId == 0)
            {
                throw new Exception("There is no ID");
                //Get all Cinemas
            }
            var cinemas = await _cinemaDataAccess.GetListByMovieIdAsync(movieId);
            var cinemaDtos = DtoConverter<Cinema, CinemaDto>.FromList(cinemas);
            return Ok(cinemaDtos);
        }

        
        // GET api/<CinemaController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CinemaDto>> GetCinemaById(int id)
        {
            var cinema = await _cinemaDataAccess.GetByIdAsync(id);
            if (cinema == null)
            {
                return NotFound();
            }
            else
            {
                var cinemaDto = DtoConverter<Cinema, CinemaDto>.From(cinema);
                return Ok(cinemaDto);
            }
        }


        /*
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
