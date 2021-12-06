using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class ReservationStub : IReservationDataAccess
    {
        public async Task<int> CreateAsync(Reservation entity)
        {
            return await Task.FromResult(1);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
