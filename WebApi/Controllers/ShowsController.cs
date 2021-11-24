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
    public class ShowsController : ControllerBase
    {
        IShowDataAccess _showDataAccess;

        public ShowsController(IShowDataAccess showDataAccess)
        {
            _showDataAccess = showDataAccess;
        }

        // GET: api/<ShowController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowDto>>> GetListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            var shows = await _showDataAccess.GetListByMovieAndCinemaIdAsync(movieId, cinemaId);
            if (shows.Count() == 0) //TODO: IsNullOrEmpty
            {
                return NotFound();
            }
            else
            {
                var showDtos = DtoConverter<Show, ShowDto>.FromList(shows);
                return Ok(showDtos);
            }
        }

        /*
        // GET api/<ShowController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShowController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ShowController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShowController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
