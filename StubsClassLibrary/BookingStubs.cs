using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Interfaces;

namespace StubsClassLibrary
{
    public class BookingStubs : IBookingDataAccess
    {
        public async Task<int> CreateAsync(Booking entity)
        {
            return await Task.FromResult(entity.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await Task.FromResult(new List<Booking>()
            {
                new Booking() { Id = 1, TotalPrice = 30, Date = DateTime.Now },
                new Booking() { Id = 2, TotalPrice = 50, Date = DateTime.Now },
                new Booking() { Id = 3, TotalPrice = 100, Date = DateTime.Now }
            });
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            Booking booking = new() { Id = id, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };

            return await Task.FromResult(booking);
        }

        public async Task<bool> UpdateAsync(Booking entity)
        {
            return await Task.FromResult(true);
        }
    }
}