using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {



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
            return null;
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<ActionResult<int>> PostAsync([FromBody] BookingDto value)
        {
            return null;
        }

        // PUT api/<BookingController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] BookingDto value)
        {
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
