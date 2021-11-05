using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Model;

namespace DataAccess.DataAccess
{
    public class BookingDataAccess : BaseDataAccess<Booking>
    {
        public BookingDataAccess(string connectionstring) : base(connectionstring) {}
    }
}
