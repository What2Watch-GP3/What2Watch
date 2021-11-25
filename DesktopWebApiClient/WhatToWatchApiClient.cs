using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopApiClient;
using DesktopApiClient.DTOs;
using RestSharp;

namespace DesktopApiClient
{
    public class WhatToWatchApiClient : IWhatToWatchApiClient
    {
        private IRestClient _client;
        public WhatToWatchApiClient(IRestClient client) => _client = client;

        public async Task<int> CreateShowAsync(ShowDto show)
        {
            var response = await _client.RequestAsync<int>(Method.POST, $"shows", show);

            if (!response.IsSuccessful) throw new Exception($"Error creating booking. Message was {response.Content}");

            return response.Data;
        }
    }
}