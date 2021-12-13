using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tools.Converters;
using WebApi.DTOs;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        IBookingDataAccess _bookingDataAccess;
        IReservationDataAccess _reservationDataAccess;

        public BookingsController(IBookingDataAccess bookingDataAccess, IReservationDataAccess reservationDataAccess)
        {
            _bookingDataAccess = bookingDataAccess;
            _reservationDataAccess = reservationDataAccess;
        }

        //// GET: api/<BookingController>
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllAsync()
        //{
        //    return null;
        //}

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
        [Authorize]
        public async Task<ActionResult<int>> PostAsync(BookingDto value)
        {
            //TODO: Change SeatIds list to a list of tickets, where we check each seat for availability
            //Probably get the show's time and a price based on the seats as well
            //List<Ticket> tickets = new ();

            Booking booking = DtoConverter<BookingDto, Booking>.From(value);
            //TODO: check if foreach or linq with select works better.
            /*foreach (int ticketId in value.TicketIds)
            {
                tickets.Add(await _ticketDataAccess.GetByIdAsync(ticketId));
            }*/
            //var reservations = value.TicketIds.ToList().Select(async ticketId => await _reservationDataAccess.GetByIdAsync(ticketId)).ToList();
            var reservations = await _reservationDataAccess.GetByUserAndShowIdAsync(value.ShowId, value.UserId);


            if ((reservations != null)&&(!reservations.Any()))
            {
                return NotFound();
            }    
            booking.Tickets = DtoConverter<Reservation, Ticket>.FromList(reservations);

            //TODO: Get Reservations from UserId na check seat Availability
            //if (!SeatsAreAvailable(value.ReservationIds) || !ShowIsValid(value.ShowId))
            //{
            //    return NotFound();
            //}
            return Ok(await _bookingDataAccess.CreateAsync(booking));
        }

        private bool ShowIsValid(int showId)
        {
            //TODO Implement seat and show validation
            return true;
        }

        private bool SeatsAreAvailable(IEnumerable<int> seatIds)
        {
            //TODO Implement seat and show validation
            return true;
        }

        //// PUT api/<BookingController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult> PutAsync(int id, [FromBody] BookingDto value)
        //{
        //    var r = DtoConverter<Booking, BookingDto>.From(value);
        //    if (!await _bookingDataAccess.UpdateAsync(r)) { return NotFound(); }
        //    else { return Ok(); }
        //}

        //// DELETE api/<BookingController>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
