using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IReservationDataAccess : IBaseDataAccess<Reservation>
    {
        Task<bool> CreateAsync(IEnumerable<Reservation> reservations);
        Task<bool> DeleteByShowAndSeatIdAsync(int showId, int seatId);
        //TODO:Consider merging all 3 methods in 1 if possible
        Task<IEnumerable<Reservation>> GetReservationsByShowIdAsync(int showId);
        Task<IEnumerable<Reservation>> GetByUserAndShowIdAsync(int showId, int userId);
        Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId);
    }
}
