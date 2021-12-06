using System;
using RestSharp;

namespace DesktopApiClient
{
    public class DesktopApiClientFactory
    {
        public static T GetDesktopApiClient<T>(string connectionstring) where T : class
        {
            switch (typeof(T).Name)
            {
                case "IDesktopApiClient": return new DesktopApiClient(new RestClient(connectionstring)) as T;
                default:
                    break;
            }
            throw new ArgumentException($"Unknown type {typeof(T).FullName}");
        }
    }
}