using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using WebApiClient.DTOs;
using Tools;
using System.Linq;
using System.Net;

namespace WebApiClient
{
    public class WebApiClient : IWebApiClient
    {
        private IRestClient _client;
        public RoomDto _room;
        private IEnumerable<ShowDto> _shows;
        public IEnumerable<MovieDto> _movies;

        public WebApiClient(IRestClient client)
        {
            _client = client;
            _client.CookieContainer = new CookieContainer();
            //_client.Timeout = 120000;
            _client.ReadWriteTimeout = 120000;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var response = await _client.RequestAsync<IEnumerable<MovieDto>>(Method.GET, $"movies");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving all movies. Message was {response.Content}.");
            _movies = response.Data;
            return _movies;
        }

        public async Task<IEnumerable<CinemaDto>> GetCinemasByMovieIdAsync(int movieId)
        {
            var response = await _client.RequestAsync<IEnumerable<CinemaDto>>(Method.GET, $"cinemas?movieId={movieId}");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving cinemas giving shows for a movie with id {movieId}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<MovieDto> GetMovieByIdAsync(int id)
        {
            var response = await _client.RequestAsync<MovieDto>(Method.GET, $"movies/{id}");

            if (!response.IsSuccessful) throw new Exception($"Error getting a movie with id {id}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesByPartOfNameAsync(string searchString)
        {
            //_client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", bearerToken));
            var response = await _client.RequestAsync<IEnumerable<MovieDto>>(Method.GET, $"movies/{searchString}");

            if (!response.IsSuccessful) throw new Exception($"Error searching movies by part of name with searchString {searchString}. Message was {response.Content}.");

            return response.Data;
        }

        public async Task<IEnumerable<ShowDto>> GetShowsByMovieAndCinemaIdAsync(int movieId, int cinemaId)
        {
            var response = await _client.RequestAsync<IEnumerable<ShowDto>>(Method.GET, $"shows?movieId={movieId}&cinemaId={cinemaId}");

            if (!response.IsSuccessful) throw new Exception($"Error retreiving shows based on movieId {movieId} and cinemaId {cinemaId}. Message was {response.Content}.");

            _shows = response.Data;

            return response.Data;
        }

        public async Task<int> ConfirmBookingAsync(BookingDto booking)
        {
            var response = await _client.RequestAsync<int>(Method.POST, $"bookings", booking);

            //TODO: decide how to be redirected
            if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return -403;
                }
                throw new Exception($"Error creating booking. Message was {response.Content}");
            }
            return response.Data;
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var response = await _client.RequestAsync<BookingDto>(Method.GET, $"bookings/{id}");

            if (!response.IsSuccessful) throw new Exception($"Error getting booking with id {id}. Message was {response.Content}");

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
            userDto = response.Data;
            var sessionCookie = response.Cookies.FirstOrDefault(x => x.Name == "X-Access-Token");
            if (sessionCookie != null)
            {
                userDto.Password = sessionCookie.Value;
            }

            //userDto.Id = (int)response.Data;
            //userDto.Password = "";

            return response.Data;
        }

        public async Task<bool> HasValidToken()
        {
            var response = await _client.RequestAsync<bool>(Method.GET, "login/validateToken");
            if (!response.IsSuccessful)
            {
                if ((int)response.StatusCode == 404)
                {
                    return false;
                }
                //TODO: based on response statuscode, do smth
                throw new Exception($"Error validating token");
            }
            return response.Data;
        }

        public async Task<CinemaDto> GetCinemaByIdAsync(int cinemaId)
        {
            var response = await _client.RequestAsync<CinemaDto>(Method.GET, $"cinemas/{cinemaId}");

            if (!response.IsSuccessful) throw new Exception($"Error getting booking with id {cinemaId}. Message was {response.Content}");

            return response.Data;
        }

        public async Task<RoomDto> GetRoomByShowIdAsync(int showId)
        {
            var response = await _client.RequestAsync<RoomDto>(Method.GET, $"rooms/{showId}");

            if (!response.IsSuccessful) throw new Exception($"Error showing the room with showId {showId}. Message was {response.Content}");

            _room = response.Data;
            return response.Data;
        }

        public async Task<IEnumerable<int>> CreateReservationAsync(IEnumerable<ReservationDto> reservationDtos)
        {

            // Map ReservationDto's SeatPosition to _seats's Seat Id
            foreach(var reservationDto in reservationDtos)
            {
                reservationDto.SeatId = GetSeatIdByPosition(reservationDto.SeatPosition);
            }

            var response = await _client.RequestAsync<IEnumerable<int>>(Method.POST, $"reservations", reservationDtos);

            if (!response.IsSuccessful) throw new Exception($"Error creating reservation. Message was {response.Content}");

            return response.Data;
        }

        public decimal GetTotalPrice(IEnumerable<string> seatPosition) => _room.Seats.ToList().Where(seat => seatPosition.Any(position => GetSeatIdByPosition(position) == seat.Id)).Sum(seats => seats.Price);
        
        private int GetSeatIdByPosition(string seatPosition)
        {
            if(_room == null)
            {
                return -1;
            }
            var positionList = seatPosition.Split("-");
            int.TryParse(positionList[0], out int row);
            int.TryParse(positionList[1], out int position);

            int index = (row * _room.Columns) + position;

            return _room.Seats.ToList()[index].Id;
        }

        public ShowDto GetShowById(int showId)
        {
            return _shows.First(show => show.Id == showId);
        }

        public void Logout()
        {
            _client.CookieContainer = new CookieContainer();
        }

        public void addToken(string value)
        {
            _client.AddDefaultParameter("X-Access-Token", value, ParameterType.Cookie);
        }

        public async Task<IEnumerable<ReservationDto>> GetReservationsAsync()
        {
            var response = await _client.RequestAsync<IEnumerable<ReservationDto>>(Method.POST, $"reservations");

            if (!response.IsSuccessful) throw new Exception($"Error showing reservations for current user. Message was {response.Content}");

            return response.Data;
        }
    }
}