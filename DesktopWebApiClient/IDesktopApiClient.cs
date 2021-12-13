using DesktopApiClient.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopApiClient
{
    public interface IDesktopApiClient
    {
        Task<int> CreateShowAsync(ShowDto show);
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<int> LoginAsync(UserDto userDto);
    }
}