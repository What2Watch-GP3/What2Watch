using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class UserStub : IUserDataAccess
    {
        public async Task<int> LoginAsync(User user)
        {
            return await Task.FromResult<int>(1);
        }
    }
}
