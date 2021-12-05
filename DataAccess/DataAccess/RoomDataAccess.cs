using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.DataAccess
{
    public class RoomDataAccess : IRoomDataAccess
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

        public Task<Room> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
