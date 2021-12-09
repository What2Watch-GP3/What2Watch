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
    public class RoomsController : ControllerBase
    {
        private IRoomDataAccess _roomDataAccess;
        private ISeatDataAccess _seatDataAccess;
        private IShowDataAccess _showDataAccess;

        public RoomsController(IRoomDataAccess roomDataAccess, ISeatDataAccess seatDataAccess, IShowDataAccess showDataAccess)
        {
            _roomDataAccess = roomDataAccess;
            _seatDataAccess = seatDataAccess;
            _showDataAccess = showDataAccess;
        }
        [HttpGet]
        public async Task<ActionResult<RoomDto>> GetByShowIdAsync(int showId)
        {
            Show show = await _showDataAccess.GetByIdAsync(showId);
            Room room = await _roomDataAccess.GetByIdAsync(show.RoomId);
            IEnumerable<Seat> seats = await _seatDataAccess.GetAllByRoomIdAsync(show.RoomId);
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
