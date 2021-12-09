using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace StubsClassLibrary
{
    public class RoomStub : IRoomDataAccess
    {
        public Task<int> CreateAsync(Room entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Room>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Room> GetByIdAsync(int id)
        {
            Room room = new Room() { Id = 1, Name= "Room name1", Rows = 5, Columns = 5};
            return await Task.FromResult(room);
        }

        public Task<bool> UpdateAsync(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
