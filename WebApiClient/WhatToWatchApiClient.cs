        private RestClient _restClient;
        public WhatToWatchApiClient(string uri) => _restClient = new RestClient(new Uri(uri));
    }
}
