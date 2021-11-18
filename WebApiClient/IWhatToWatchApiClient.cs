using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient.DTOs;

namespace WebApiClient
{
    interface IWhatToWatchApiClient
    {
        //Movie methods
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<IEnumerable<MovieDto>> GetMovieListByPartOfNameAsync(string searchString);
        Task<MovieDto> GetMovieByIdAsync(int id);

        //Cinema methods
        Task<IEnumerable<CinemaDto>> GetCinemaListByMovieIdAsync(int movieId);

        //Show methods
        Task<IEnumerable<ShowDto>> GetShowListByMovieAndCinemaIdAsync(int movieId, int cinemaId);
    }
}
