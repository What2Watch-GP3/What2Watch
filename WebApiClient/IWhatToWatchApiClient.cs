using System.Threading.Tasks;
using WebApiClient.DTOs;

namespace WebApiClient
{
    public interface IWhatToWatchApiClient
    {
        Task<int> CreateBookingAsync(BookingDto booking);
        Task<BookingDto> GetBookingByIdAsync(int id);
    }
}
