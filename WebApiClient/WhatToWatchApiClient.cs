using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WebApiClient.DTOs;

namespace WebApiClient
{
    class WhatToWatchApiClient : IWhatToWatchApiClient
    {
        private IRestClient _client;
        public WhatToWatchApiClient(IRestClient client) => _client = client;

        public Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CinemaDto>> GetCinemaListByMovieIdAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDto> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieDto>> GetMovieListByPartOfNameAsync(string searchString)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShowDto>> GetShowListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            throw new NotImplementedException();
        }
    }
}