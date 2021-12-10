﻿using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
    }
}
