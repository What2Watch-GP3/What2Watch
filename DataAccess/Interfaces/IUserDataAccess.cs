using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    interface IUserDataAccess
    {
        Task<int> LoginAsync(string email, string password); 
    }
}
