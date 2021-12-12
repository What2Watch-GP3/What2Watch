using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserDataAccess
    {
        Task<User> LoginAsync(User user);
    }
}
