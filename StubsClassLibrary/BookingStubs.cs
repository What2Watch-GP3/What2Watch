using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Interfaces;

namespace StubsClassLibrary
{
    public class BookingStubs : IBookingDataAccess
    {
        public async Task<int> CreateAsync(Booking entity)
        {
            return await Task.FromResult<int>(1);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.FromResult<bool>(true);
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
            Booking booking1 = new Booking() { Id = 1, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };
            Booking booking2 = new Booking() { Id = 2, TotalPrice = 50, Date = new DateTime(2021, 10, 9) };
            Booking booking3 = new Booking() { Id = 3, TotalPrice = 100, Date = new DateTime(2021, 2, 8) };
            IEnumerable<Booking> bookings = new List<Booking>() { booking1, booking2, booking3 };


            return await Task.FromResult<IEnumerable<Booking>>(bookings);
        }

        public async Task<Booking> GetByIdAsync(int id)
        {
            Booking booking = new Booking() { Id = 1, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };

            return await Task.FromResult<Booking>(booking);
        }

        public async Task<IEnumerable<Booking>> GetListByPartOfNameAsync(string searchString)
        {
            Booking booking1 = new Booking() { Id = 1, TotalPrice = 30, Date = new DateTime(2021, 6, 10) };
            Booking booking2 = new Booking() { Id = 2, TotalPrice = 50, Date = new DateTime(2021, 10, 9) };
            Booking booking3 = new Booking() { Id = 3, TotalPrice = 100, Date = new DateTime(2021, 2, 8) };
            IEnumerable<Booking> bookings = new List<Booking>() { booking1, booking2, booking3 };


            return await Task.FromResult<IEnumerable<Booking>>(bookings);
        }

        public async Task<bool> UpdateAsync(Booking entity)
        {
            return await Task.FromResult<bool>(true);
        }

    }
}
