using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.DTOs.Converters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        IReservationDataAccess _reservationDataAccess;
        public ReservationsController(IReservationDataAccess reservationDataAccess)
        {
            _reservationDataAccess = reservationDataAccess;
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync([FromBody] ReservationDto reservationDto)
        {
            if (reservationDto != null)
            {
                var reservation = DtoConverter<ReservationDto, Reservation>.From(reservationDto);
                var reservationId = await _reservationDataAccess.CreateAsync(reservation);
                return Ok(reservationId);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
