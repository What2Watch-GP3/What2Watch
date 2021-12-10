using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Tools.Converters;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    public class RoomsController : ControllerBase
    {
        private IRoomDataAccess _roomDataAccess;
        private ISeatDataAccess _seatDataAccess;
        private IShowDataAccess _showDataAccess;
        private ITicketDataAccess _ticketDataAccess;

        public RoomsController(IRoomDataAccess roomDataAccess, ISeatDataAccess seatDataAccess, IShowDataAccess showDataAccess, ITicketDataAccess ticketDataAccess)
        {
            _roomDataAccess = roomDataAccess;
            _seatDataAccess = seatDataAccess;
            _showDataAccess = showDataAccess;
            _ticketDataAccess = ticketDataAccess;
        }
        [HttpGet]
        public async Task<ActionResult<RoomDto>> GetByShowIdAsync(int showId)
        {
            Show show = await _showDataAccess.GetByIdAsync(showId);
            Room room = await _roomDataAccess.GetByIdAsync(show.RoomId);
            IEnumerable<Seat> seats = await _seatDataAccess.GetAllByRoomIdAsync(show.RoomId);
            IEnumerable<Ticket> tickets = await _ticketDataAccess.GetTicketsByShowIdAsync(showId);
            if (show == null || room == null || seats == null)
            {
                return NotFound();
            }
            else
            {
                RoomDto roomDto = DtoConverter<Room, RoomDto>.From(room);
                IEnumerable<SeatDto> seatsDto = DtoConverter<Seat, SeatDto>.FromList(seats);
                
                roomDto.Seats = seatsDto;
                return Ok(roomDto);
            }
        }
    
    }
}
