using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IReservationDataAccess : IBaseDataAccess<Reservation>
    {
        Task<IEnumerable<int>> CreateAsync(IEnumerable<Reservation> reservations);
    }
}
