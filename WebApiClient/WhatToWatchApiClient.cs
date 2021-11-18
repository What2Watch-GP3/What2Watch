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
        public WhatToWatchApiClient(string uri) => _restClient = new RestClient(new Uri(uri));
    }
}