using DataAccess.Interfaces;
using DataAccess.Models;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class UserStub : IUserDataAccess
    {
        public async Task<User> LoginAsync(User user)
        {
            return await Task.FromResult(new User() { Id = 1, Name = "Kathi"});
        }
    }
}