using DesktopApiClient.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesktopApiClient
{
    public interface IWhatToWatchApiClient
    {
        Task<int> CreateShowAsync(ShowDto show);
    }
}
