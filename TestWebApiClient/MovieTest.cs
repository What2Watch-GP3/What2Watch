using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiClient;

namespace TestWebApiClient
{
    public class MovieTest
    {
        private IWhatToWatchApiClient _client = new WhatToWatchApiClient(Configuration.WEB_API_URL);
    }
}
