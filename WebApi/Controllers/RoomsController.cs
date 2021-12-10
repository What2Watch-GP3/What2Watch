using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.DTOs.Converters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IRoomDataAccess _roomDataAccess;
        private ISeatDataAccess _seatDataAccess;
        private IShowDataAccess _showDataAccess;
        private ITicketDataAccess _ticketDataAccess;
        private IReservationDataAccess _reservationDataAccess;

        public RoomsController(IRoomDataAccess roomDataAccess, ISeatDataAccess seatDataAccess, IShowDataAccess showDataAccess, ITicketDataAccess ticketDataAccess, IReservationDataAccess reservationDataAccess)
        {
            _roomDataAccess = roomDataAccess;
            _seatDataAccess = seatDataAccess;
            _showDataAccess = showDataAccess;
            _ticketDataAccess = ticketDataAccess;
            _reservationDataAccess = reservationDataAccess;
        }

        [Route("{showId:int}")]
        [HttpGet]
        public async Task<ActionResult<RoomDto>> GetByShowIdAsync(int showId)
        {
            Show show = await _showDataAccess.GetByIdAsync(showId);
            Room room = await _roomDataAccess.GetByIdAsync(show.RoomId);
            IEnumerable<Seat> seats = await _seatDataAccess.GetAllByRoomIdAsync(show.RoomId);
            IEnumerable<Ticket> tickets = await _ticketDataAccess.GetTicketsByShowIdAsync(showId);
            IEnumerable<Reservation> reservations = await _reservationDataAccess.GetReservationsByShowIdAsync(showId);

            if (show == null || room == null || seats == null)
            {
                return NotFound();
            }
            else
            {

                RoomDto roomDto = DtoConverter<Room, RoomDto>.From(room);
                IEnumerable<SeatDto> seatsDto = DtoConverter<Seat, SeatDto>.FromList(seats).ToList();
                
                seatsDto.ToList().Where(seat => tickets.Any(ticket => ticket.SeatId == seat.Id)).ToList().ForEach(seat => seat.IsOccupied = true);
                seatsDto.ToList().Where(seat => reservations.Any(reservation => reservation.SeatId == seat.Id)).ToList().ForEach(seat => seat.IsOccupied = true);

                roomDto.Seats = seatsDto;
                return Ok(roomDto);
            }
        }
    }
}
