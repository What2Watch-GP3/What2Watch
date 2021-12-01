using Dapper;
using DataAccess.Interfaces;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class BookingDataAccess : BaseDataAccess<Booking>, IBookingDataAccess
    {
        public BookingDataAccess(string connectionstring) : base(connectionstring)
        {
            //Values = new List<string> { "total_price", "date" };
            //RawValues = new List<string> { "TotalPrice", "Date" };
        } 
    }

}
