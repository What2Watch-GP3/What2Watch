using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApiClient.DTOs;

namespace WebApiClient
{
    public interface IWebApiClient
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<IEnumerable<CinemaDto>> GetCinemasByMovieIdAsync(int movieId);
        Task<MovieDto> GetMovieByIdAsync(int id);
        Task<IEnumerable<MovieDto>> GetMoviesByPartOfNameAsync(string searchString);
        Task<IEnumerable<ShowDto>> GetShowsByMovieAndCinemaIdAsync(int movieId, int cinemaId);
        Task<int> ConfirmBookingAsync(BookingDto booking);
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task <CinemaDto> GetCinemaByIdAsync(int cinemaId);
        Task<int> LoginAsync(UserDto userDto);
        Task<bool> HasValidToken();
        Task<int> CreateReservationAsync(ReservationDto reservationDto);

    }
}
