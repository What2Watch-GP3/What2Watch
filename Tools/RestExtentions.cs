using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

// Original code from https://github.com/UCN-programming-3-jfk/BlogSharp/blob/master/WebApiClient/RestClientExtensions.cs

namespace Tools
{
    /// <summary>
    /// This class provides extension methods which enable JSON serialization and HTTP calls to be provided in one line
    /// </summary>
    public static class RestExtentions
    {
        public static async Task<IRestResponse<T>> RequestAsync<T>(this IRestClient client, Method method, string resource = null, object body = null)
        {
            var request = new RestRequest(resource, method, DataFormat.Json);
            if (body != null)
            {
                request.AddJsonBody(JsonSerializer.Serialize(body));
            }
            return await client.ExecuteAsync<T>(request, method);
        }

        public static async Task<IRestResponse> RequestAsync(this IRestClient client, Method method, string resource = null, object body = null)
        {
            var request = new RestRequest(resource, method, DataFormat.Json);
            if (body != null)
            {
                request.AddJsonBody(JsonSerializer.Serialize(body));
            }
            return await client.ExecuteAsync(request, method);
        }
    }
}
