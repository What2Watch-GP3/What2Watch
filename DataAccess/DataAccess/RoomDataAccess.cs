using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.DataAccess
{
    public class RoomDataAccess : BaseDataAccess<Room>, IRoomDataAccess
    {
             public RoomDataAccess(string connectionString) : base(connectionString) { }
             
    }
}
