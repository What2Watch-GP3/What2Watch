using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Interfaces
{
    interface IBookingDataAccess
    {
        Task<int> CreateAsync(Booking booking);
        Task<int> GetAsync(int id);

    }
}
