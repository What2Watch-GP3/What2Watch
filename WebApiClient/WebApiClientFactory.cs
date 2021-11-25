using System;
using RestSharp;

namespace WebApiClient
{
    public class WebApiClientFactory
    {

        public static T GetWebApiClient<T>(string connectionstring) where T : class
        {
            switch (typeof(T).Name)
            {
                case "IWhatToWatchApiClient": return new WhatToWatchApiClient(new RestClient(connectionstring)) as T;
                default:
                    break;
            }
            //return (T)Activator.CreateInstance(typeof(T), connectionstring);

            throw new ArgumentException($"Unknown type {typeof(T).FullName}");
        }
    }
}

