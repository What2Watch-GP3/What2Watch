using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<int>>> CreateAsync([FromBody] IEnumerable<ReservationDto> reservationDtos)
        {
            if (reservationDtos != null)
            {
                var reservations = DtoConverter<ReservationDto, Reservation>.FromList(reservationDtos);
                var reservationIds = await _reservationDataAccess.CreateAsync(reservations);
                return Ok(reservationIds);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
