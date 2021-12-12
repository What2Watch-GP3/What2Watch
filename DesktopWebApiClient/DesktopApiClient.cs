using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopApiClient.DTOs;
using RestSharp;
using Tools;

namespace DesktopApiClient
{
    public class DesktopApiClient : IDesktopApiClient
    {
        private IRestClient _client;
        public DesktopApiClient(IRestClient client) => _client = client;

        public async Task<int> CreateShowAsync(ShowDto show)
        {
            var response = await _client.RequestAsync<int>(Method.POST, $"shows", show);

            if (!response.IsSuccessful) throw new Exception($"Error creating booking. Message was {response.Content}");

            return response.Data;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var response = await _client.RequestAsync<IEnumerable<MovieDto>>(Method.GET, $"movies");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving all movies. Message was {response.Content}.");

            return response.Data;
        }
    }
}