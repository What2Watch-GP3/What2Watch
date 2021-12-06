using Dapper;
using DataAccess.Interfaces;
using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public class ReservationDataAccess : BaseDataAccess<Reservation>, IReservationDataAccess
    {
        public ReservationDataAccess(string connectionstring) : base(connectionstring)
        {
            Values = new List<string> { "total_price", "date" };
            RawValues = new List<string> { "TotalPrice", "Date" };
        } 
    }

}
