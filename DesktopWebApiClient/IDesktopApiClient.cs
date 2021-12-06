using DesktopApiClient.DTOs;
using System.Threading.Tasks;

namespace DesktopApiClient
{
    public interface IDesktopApiClient
    {
        Task<int> CreateShowAsync(ShowDto show);
    }
}