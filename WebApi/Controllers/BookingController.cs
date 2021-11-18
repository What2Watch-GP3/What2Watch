using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.DataAccess;
using DataAccess.Interfaces;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.DTOs;
using WebApi.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        IBookingDataAccess _bookingDataAccess;

        public BookingController(IConfiguration configuration)
        {
            _bookingDataAccess = new BookingDataAccess(configuration.GetConnectionString("DefaultConnection"));
        }

        public BookingController(IBookingDataAccess bookingDataAccess)
        {
            _bookingDataAccess = bookingDataAccess;
        }

        // GET: api/<BookingController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllAsync()
        {
            return null;
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetByIdAsync(int id)
        {
            var booking = await _bookingDataAccess.GetByIdAsync(id);
            if (booking == null) 
            { 
                return NotFound(); 
            }
            else
            { 
                return Ok(booking); 
            }
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] BookingDto value)
        {
            var booking = DtoConverter<BookingDto, Booking>.From(value);
            return Ok(await _bookingDataAccess.CreateAsync(booking));
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] BookingDto value)
        {
            //var r = DtoConverter<Booking, BookingDto>.From(value);
            //if (!await _bookingDataAccess.UpdateAsync(r)) { return NotFound(); }
            //else { return Ok(); }
            return null;
        }

        // DELETE api/<BookingController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            return null;
        }
    }
}
