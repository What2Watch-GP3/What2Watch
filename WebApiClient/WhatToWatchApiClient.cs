using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using WebApiClient.DTOs;

namespace WebApiClient
{
    public class WhatToWatchApiClient : IWhatToWatchApiClient
    {
        private IRestClient _client;
        public WhatToWatchApiClient(IRestClient client) => _client = client;

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var response = await _client.RequestAsync<IEnumerable<MovieDto>>(Method.GET, $"movies");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving all movies. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<IEnumerable<CinemaDto>> GetCinemasByMovieIdAsync(int movieId)
        {
            var response = await _client.RequestAsync<IEnumerable<CinemaDto>>(Method.GET, $"cinemas?movieId={movieId}");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving cinemas giving shows for a movie with id {movieId}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var response = await _client.RequestAsync<MovieDto>(Method.GET, $"movies/{id}");

            if (!response.IsSuccessful) throw new Exception($"Error getting a movie with id {id}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByPartOfNameAsync(string searchString)
        {
            var response = await _client.RequestAsync<IEnumerable<MovieDto>>(Method.GET, $"movies/{searchString}");

            if (!response.IsSuccessful) throw new Exception($"Error searching movies by part of name with searchString {searchString}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<IEnumerable<ShowDto>> GetShowsByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            var response = await _client.RequestAsync<IEnumerable<ShowDto>>(Method.GET, $"shows?movieId={movieId}&cinemaId={cinemaId}");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving shows based on movieId {movieId} and cinemaId {cinemaId}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<int> ConfirmBookingAsync(BookingDto booking)
        {
            var response = await _client.RequestAsync<int>(Method.POST, $"bookings", booking);

            if (!response.IsSuccessful) throw new Exception($"Error creating booking. Message was {response.Content}");

            return response.Data;
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var response = await _client.RequestAsync<BookingDto>(Method.GET, $"bookings/{id}");

            if (!response.IsSuccessful) throw new Exception($"Error getting booking with id {id}. Message was {response.Content}");

            return response.Data;
        }

        public async Task<UserDto> LoginAsync(UserDto userDto)
        {
            var response = await _client.RequestAsync<int>(Method.POST, "login", userDto);
            if (!response.IsSuccessful)
            {
                //TODO: based on response statuscode, do smth
                throw new Exception($"Error login in for userDto email={userDto.Email}");
            }
            userDto.Id = (int)response.Data;
            userDto.Password = "";
            return userDto;
        }
    }
}