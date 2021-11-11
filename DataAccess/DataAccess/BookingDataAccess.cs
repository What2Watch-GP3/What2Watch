using DataAccess.Interfaces;
using DataAccess.Model;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public class BookingDataAccess : BaseDataAccess<Booking>, IBookingDataAccess
    {
        public BookingDataAccess(string connectionstring) : base(connectionstring)
        {
            Values = new List<string> { "total_price", "date" };
            RawValues = new List<string> { "TotalPrice", "Date" };
        }
    }
}
