using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WebApiClient
{
    class WhatToWatchApiClient : IWhatToWatchApiClient
    {
        private RestClient _restClient;
        public BlogSharpApiClient(string uri) => _restClient = new RestClient(new Uri(uri));

        public async Task<int> CreateAuthorAsync(BookingDto entity)
        {

        }
        public async Task<IEnumerable<BookingDto>> GetAllAuthorsAsync()
        {



        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {

        }

    }
}
