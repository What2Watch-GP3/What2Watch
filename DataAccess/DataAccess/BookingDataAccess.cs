using DataAccess.Interfaces;
using DataAccess.Model;

namespace DataAccess.DataAccess
{
    public class BookingDataAccess : BaseDataAccess<Booking>, IBookingDataAccess
    {
        public BookingDataAccess(string connectionstring) : base(connectionstring) { }
    }
}
