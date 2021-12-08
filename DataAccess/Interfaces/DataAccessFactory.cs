using System;
using DataAccess.DataAccess;

namespace DataAccess.Interfaces
{
    public class DataAccessFactory
    {
        public static T GetDataAccess<T>(string connectionString) where T : class
        {
            switch (typeof(T).Name)
            {
                case "IBookingDataAccess": return new BookingDataAccess(connectionString) as T;
                case "ICinemaDataAccess": return new CinemaDataAccess(connectionString) as T;
                case "IMovieDataAccess": return new MovieDataAccess(connectionString) as T;
                case "IShowDataAccess": return new ShowDataAccess(connectionString) as T;
                case "IUserDataAccess": return new UserDataAccess(connectionString) as T;
                case "IRoomDataAccess": return new RoomDataAccess(connectionString) as T;
                case "ISeatDataAccess": return new SeatDataAccess(connectionString) as T;
                default:
                    break;
            }

            throw new ArgumentException($"Unknown type {typeof(T).FullName}");
        }
    }
}

