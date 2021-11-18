using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiClient
{
     static class RestExtentions
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
