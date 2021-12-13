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

        //TODO: Make this return a full UserDto in order to display user details later
        public async Task<UserDto> LoginAsync(UserDto userDto)
        {
            var response = await _client.RequestAsync<UserDto>(Method.POST, "login", userDto);
            if (!response.IsSuccessful)
            {
                if ((int)response.StatusCode == 404)
                {
                    return null;
                }
                //TODO: based on response statuscode, do smth
                throw new Exception($"Error login in for userDto email={userDto.Email}");
            }
            // TODO: Ignore password in a better way
            userDto.Password = "";
            userDto = response.Data;
            return response.Data;
        }
    }
}