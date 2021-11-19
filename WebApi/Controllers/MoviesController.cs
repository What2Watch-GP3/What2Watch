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
    public class MoviesController : ControllerBase
    {
        IMovieDataAccess _movieDataAccess;

        public MoviesController(IMovieDataAccess movieDataAccess)
        {
            _movieDataAccess = movieDataAccess;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task <ActionResult<IEnumerable<MovieDto>>> GetAllAsync()
        {
            var movies = await _movieDataAccess.GetAllAsync();
            var movieDtos = DtoConverter<Movie, MovieDto>.FromList(movies);
            return Ok(movieDtos);
        }
      

        // GET: api/<MovieController>
        [HttpGet("{searchString}")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetListByPartOfNameAsync(string searchString)
        {
            IEnumerable<Movie> matchingMovies;
            IEnumerable<MovieDto> matchingMovieDtos;
            if (!string.IsNullOrEmpty(searchString))
            {
                matchingMovies = await _movieDataAccess.GetListByPartOfNameAsync(searchString);
            }
            else
            {
                matchingMovies = await _movieDataAccess.GetAllAsync();
            }
            matchingMovieDtos = DtoConverter<Movie, MovieDto>.FromList(matchingMovies);
            return Ok(matchingMovieDtos);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetByIdAsync(int id)
        {
            var movie = await _movieDataAccess.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                var movieDto = DtoConverter<Movie, MovieDto>.From(movie);
                return Ok(movieDto);
            }
        }



        /* POST api/<MovieController>
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync([FromBody] MovieDto movie)
        {
            

        }*/

            /*
        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] MovieDto movie)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
            */
    }

}
