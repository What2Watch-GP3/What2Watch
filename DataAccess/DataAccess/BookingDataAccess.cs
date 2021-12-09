using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public class BookingDataAccess : BaseDataAccess<Booking>, IBookingDataAccess
    {
        public BookingDataAccess(string connectionstring) : base(connectionstring)
        {
            Values = new List<string> { "total_price", "date" };
        } 
    }
}
