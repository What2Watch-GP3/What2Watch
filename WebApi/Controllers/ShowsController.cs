using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
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
            if (!shows.Any()) //TODO: IsNullOrEmpty
            {
                return NotFound();
            }
            else
            {
                var showDtos = DtoConverter<Show, ShowDto>.FromList(shows);
                return Ok(showDtos);
            }
        }

        //POST api/<ShowController>
        [HttpPost]
        public async Task<ActionResult<int>> CreateShowAsync([FromBody] ShowDto showDto)
        {
            if (showDto != null)
            {
                var show = DtoConverter<ShowDto, Show>.From(showDto);
                var showId = await _showDataAccess.CreateAsync(show);
                return Ok(showId);
            }
            else
            {
                return BadRequest();
            }
        }


        /*
        // GET api/<ShowController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
