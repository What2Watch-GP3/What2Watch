using System;
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
    }
}