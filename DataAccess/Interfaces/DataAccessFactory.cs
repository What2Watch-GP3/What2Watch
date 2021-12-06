using System;
using DataAccess.DataAccess;

namespace DataAccess.Interfaces
{
    public class DataAccessFactory
    {
        public static T GetDataAccess<T>(string connectionstring) where T : class
        {
            switch (typeof(T).Name)
            {
                case "IBookingDataAccess": return new BookingDataAccess(connectionstring) as T;
                case "ICinemaDataAccess": return new CinemaDataAccess(connectionstring) as T;
                case "IMovieDataAccess": return new MovieDataAccess(connectionstring) as T;
                case "IShowDataAccess": return new ShowDataAccess(connectionstring) as T;
                case "IUserDataAccess": return new UserDataAccess(connectionstring) as T;
                default:
                    break;
            }

            throw new ArgumentException($"Unknown type {typeof(T).FullName}");
        }
    }
}

