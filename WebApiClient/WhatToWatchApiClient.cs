using System;
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
        private IRestClient _client;
        public WhatToWatchApiClient(IRestClient client) => _client = client;

        public async Task<int> CreateBookingAsync(BookingDto booking)
        {
            var response = await _client.RequestAsync<int>(Method.POST, $"booking", booking);

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error creating booking. Message was {response.Content}");
            }
            return response.Data;
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var response = await _client.RequestAsync<BookingDto>(Method.GET, $"booking/{id}");

            if (!response.IsSuccessful)
            {
                throw new Exception($"Error getting booking with id {id}. Message was {response.Content}");
            }
            return response.Data;
        }
    }
}