using DataAccess.Interfaces;
using DataAccess.Models;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class UserStub : IUserDataAccess
    {
        public async Task<int> LoginAsync(User user)
        {
            return await Task.FromResult(1);
        }
    }
}