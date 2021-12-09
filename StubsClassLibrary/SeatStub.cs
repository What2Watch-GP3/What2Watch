using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace StubsClassLibrary
{
    public class SeatStub : ISeatDataAccess
    {
        public async Task<IEnumerable<Seat>> GetAllByRoomIdAsync(int roomId)
        {
            List<Seat> seatList = new List<Seat>();
            seatList.Add(new Seat() { Id = 1, Position = 2, RowNumber = 3, IsAvailable = false, Type = "Regular", Price = 40});
            seatList.Add(new Seat() { Id = 2, Position = 7, RowNumber = 1, IsAvailable = false, Type = "Regular", Price = 40 });
            seatList.Add(new Seat() { Id = 3, Position = 5, RowNumber = 2, IsAvailable = true, Type = "Regular", Price = 40 });
            seatList.Add(new Seat() { Id = 4, Position = 5, RowNumber = 4, IsAvailable = true, Type = "Premium", Price = 80 });
            return await Task.FromResult(seatList);
        }


    }
}
