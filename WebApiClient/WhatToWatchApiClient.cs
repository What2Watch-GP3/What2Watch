﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WebApiClient.DTOs;

namespace WebApiClient
{
    public class WhatToWatchApiClient : IWhatToWatchApiClient
    {
        private RestClient _restClient;
        public WhatToWatchApiClient(string uri) => _restClient = new RestClient(new Uri(uri));

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var response = await _restClient.RequestAsync<IEnumerable<MovieDto>>(Method.GET, $"movies");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving all movies. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<IEnumerable<CinemaDto>> GetCinemaListByMovieIdAsync(int movieId)
        {
            var response = await _restClient.RequestAsync<IEnumerable<CinemaDto>>(Method.GET, $"cinemas?movieId={movieId}");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving cinemas giving shows for a movie with id {movieId}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var response = await _restClient.RequestAsync<MovieDto>(Method.GET, $"movies/{id}");

            if (!response.IsSuccessful) throw new Exception($"Error getting a movie with id {id}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<IEnumerable<MovieDto>> GetMovieListByPartOfNameAsync(string searchString)
        {
            var response = await _restClient.RequestAsync<IEnumerable<MovieDto>>(Method.GET, $"movies?search={searchString}");

            if (!response.IsSuccessful) throw new Exception($"Error searching movies by part of name with searchString {searchString}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<IEnumerable<ShowDto>> GetShowListByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            var response = await _restClient.RequestAsync<IEnumerable<ShowDto>>(Method.GET, $"shows?movieId={movieId}&cinemaId={cinemaId}");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving shows based on movieId {movieId} and cinemaId {cinemaId}. Message was {response.Content}.");

            return response.Data;
        }
    }
}