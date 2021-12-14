using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Converters;
using WebApi.DTOs;

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
        public async Task<ActionResult<bool>> CreateAsync([FromBody] IEnumerable<ReservationDto> reservationDtos)
        {
            if (reservationDtos != null)
            {
                var reservations = DtoConverter<ReservationDto, Reservation>.FromList(reservationDtos);
                bool isConfirmed = await _reservationDataAccess.CreateAsync(reservations);
                return Ok(isConfirmed);
            }
            else
            {
                return BadRequest();
            }
        }

        //Get api/reservations
        //TODO: make this accept an option show id and either return all reservations - thus cart or by showid- thus confirm booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetAllAsync()
        {
            var temp = HttpContext.User.Claims;
            var userId = Convert.ToInt32(HttpContext.User.FindFirst("id").Value);
            IEnumerable<Reservation> reservations = await _reservationDataAccess.GetByUserIdAsync(userId);
            var reservationDtos = DtoConverter<Reservation, ReservationDto>.FromList(reservations);
            if (reservationDtos != null && reservationDtos.Any())
            {
                return Ok(reservationDtos);
            }
            else
            {
                return NotFound();
            }
        }


    }
}
