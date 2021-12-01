using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserDataAccess
    {
        Task<int> LoginAsync(User user);
    }
}
