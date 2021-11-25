using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StubsClassLibrary
{
    public class RestClientStub : IRestClient
    {
        public object ResponseData { get; set; }

        public RestClientStub() : base() { }

        public Task<IRestResponse> ExecuteAsync(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default)
        {
            IRestResponse response = new RestResponse()
            {
                ContentType = "application/json",
                Content = "RestClient Stub for testing",
                ResponseStatus = ResponseStatus.Completed, 
                StatusCode = HttpStatusCode.OK 
            };
            return Task.FromResult(response);
        }

        public Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, Method httpMethod, CancellationToken cancellationToken = default)
        {
            IRestResponse<T> response = new RestResponse<T>()
            {
                ContentType = "application/json",
                Content = "RestClient Stub for testing",
                ResponseStatus = ResponseStatus.Completed,
                StatusCode = HttpStatusCode.OK,
                Data = (T)ResponseData
            };
            return Task.FromResult(response);
        }

        #region Properties
        public CookieContainer CookieContainer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutomaticDecompression { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? MaxRedirects { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string UserAgent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Timeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ReadWriteTimeout { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UseSynchronizationContext { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAuthenticator Authenticator { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Uri BaseUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Encoding Encoding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool ThrowOnDeserializationError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool FailOnDeserializationError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool ThrowOnAnyError { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ConnectionGroupName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool PreAuthenticate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool UnsafeAuthenticatedConnectionSharing { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<Parameter> DefaultParameters => throw new NotImplementedException();

        public string BaseHost { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AllowMultipleDefaultParametersWithSameName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public X509CertificateCollection ClientCertificates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWebProxy Proxy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public RequestCachePolicy CachePolicy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Pipelined { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool FollowRedirects { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Unused interface methods
        public void AddHandler(string contentType, Func<IDeserializer> deserializerFactory)
        {
            throw new NotImplementedException();
        }

        public void AddHandler(string contentType, IDeserializer deserializer)
        {
            throw new NotImplementedException();
        }

        public Uri BuildUri(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public string BuildUriWithoutQueryParameters(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public void ClearHandlers()
        {
            throw new NotImplementedException();
        }

        public void ConfigureWebRequest(Action<HttpWebRequest> configurator)
        {
            throw new NotImplementedException();
        }

        public IRestResponse<T> Deserialize<T>(IRestResponse response)
        {
            throw new NotImplementedException();
        }

        public byte[] DownloadData(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public byte[] DownloadData(IRestRequest request, bool throwOnError)
        {
            throw new NotImplementedException();
        }

        public IRestResponse Execute(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public IRestResponse Execute(IRestRequest request, Method httpMethod)
        {
            throw new NotImplementedException();
        }

        public IRestResponse<T> Execute<T>(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public IRestResponse<T> Execute<T>(IRestRequest request, Method httpMethod)
        {
            throw new NotImplementedException();
        }

        public IRestResponse ExecuteAsGet(IRestRequest request, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public IRestResponse<T> ExecuteAsGet<T>(IRestRequest request, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public IRestResponse ExecuteAsPost(IRestRequest request, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public IRestResponse<T> ExecuteAsPost<T>(IRestRequest request, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecuteAsync<T>(IRestRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecuteAsync(IRestRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
        {
            throw new NotImplementedException();
        }

        public RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback)
        {
            throw new NotImplementedException();
        }

        public RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, Method httpMethod)
        {
            throw new NotImplementedException();
        }

        public RestRequestAsyncHandle ExecuteAsync<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, Method httpMethod)
        {
            throw new NotImplementedException();
        }

        public RestRequestAsyncHandle ExecuteAsyncGet(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public RestRequestAsyncHandle ExecuteAsyncGet<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public RestRequestAsyncHandle ExecuteAsyncPost(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public RestRequestAsyncHandle ExecuteAsyncPost<T>(IRestRequest request, Action<IRestResponse<T>, RestRequestAsyncHandle> callback, string httpMethod)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecuteGetAsync<T>(IRestRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecuteGetAsync(IRestRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecuteGetTaskAsync<T>(IRestRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecuteGetTaskAsync(IRestRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecutePostAsync<T>(IRestRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecutePostAsync(IRestRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecutePostTaskAsync<T>(IRestRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecutePostTaskAsync(IRestRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse<T>> ExecuteTaskAsync<T>(IRestRequest request, Method httpMethod)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecuteTaskAsync(IRestRequest request, CancellationToken token, Method httpMethod)
        {
            throw new NotImplementedException();
        }

        public Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
        {
            throw new NotImplementedException();
        }

        public void RemoveHandler(string contentType)
        {
            throw new NotImplementedException();
        }

        public IRestClient UseQueryEncoder(Func<string, Encoding, string> queryEncoder)
        {
            throw new NotImplementedException();
        }

        public IRestClient UseSerializer(Func<IRestSerializer> serializerFactory)
        {
            throw new NotImplementedException();
        }

        public IRestClient UseSerializer<T>() where T : IRestSerializer, new()
        {
            throw new NotImplementedException();
        }

        public IRestClient UseSerializer(IRestSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public IRestClient UseUrlEncoder(Func<string, string> encoder)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
