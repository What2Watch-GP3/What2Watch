using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DesktopApiClient;
using RestSharp;

namespace DesktopApiClient
{
    public class WhatToWatchApiClient : IWhatToWatchApiClient
    {
        private IRestClient _client;
        public WhatToWatchApiClient(IRestClient client) => _client = client;

    }
}