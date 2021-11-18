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
        private RestClient _restClient;
        public WhatToWatchApiClient(string uri) => _restClient = new RestClient(new Uri(uri));

        public async Task<int> CreateBookingAsync(BookingDto booking)
        {
            //var response = await _restClient.RequestAsync<int>(Method.POST, $"booking", booking);

            //if (!response.IsSuccessful)
            //{
            //    throw new Exception($"Error creating booking. Message was {response.Content}");
            //}
            //return response.Data;
            throw new NotImplementedException();
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            //var response = await _restClient.RequestAsync<int>(Method.GET, $"booking/{id}");

            //if (!response.IsSuccessful)
            //{
            //    throw new Exception($"Error getting booking with id {id}. Message was {response.Content}");
            //}
            //return response.Data;
            throw new NotImplementedException();
        }
    }
}