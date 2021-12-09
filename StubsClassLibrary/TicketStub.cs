using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace StubsClassLibrary
{
    public class TicketStub : ITicketDataAccess
    {

        public Task<int> CreateAsync(Ticket entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsByShowIdAsync(int showId)
        {

                return await Task.FromResult(new List<Ticket>(){
                new Ticket() { Id = 1, SeatId = 2, ShowId= 1 },
                new Ticket() { Id = 2, SeatId = 3, ShowId= 1 },
                new Ticket() { Id = 3, SeatId = 4, ShowId= 1 },
                new Ticket() { Id = 4, SeatId = 5, ShowId= 1 }
        });
            
        }

        public Task<bool> UpdateAsync(Ticket entity)
        {
            throw new NotImplementedException();
        }
    }
}
