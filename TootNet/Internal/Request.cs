using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TootNet.Internal
{
    public enum MethodType
    {
        Get = 0,
        Post = 1,
        Delete = 2,
        Patch = 3,
        Put = 4,
    }

    public class AsyncResponse : IDisposable
    {
        public AsyncResponse(HttpResponseMessage source)
        {
            Source = source;
        }

        public HttpResponseMessage Source { get; }

        public Task<Stream> GetResponseStreamAsync()
        {
            return Source.Content.ReadAsStreamAsync();
        }

        public Task<string> GetResponseStringAsync()
        {
            return Source.Content.ReadAsStringAsync();
        }

        public Task<byte[]> GetResponseByteArrayAsync()
        {
            return Source.Content.ReadAsByteArrayAsync();
        }

        public void Dispose()
        {
            Source?.Dispose();
        }
    }

    internal static class Request
    {
        internal static async Task<AsyncResponse> HttpGetAsync(HttpClient httpClient, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var response = await httpClient.GetAsync(Utils.CreateUrlParameter(url, param)).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }

        internal static async Task<AsyncResponse> HttpPostAsync(HttpClient httpClient, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            MultipartFormDataContent httpContent = null;
            if (param != null && param.Any()) {
                httpContent = new MultipartFormDataContent();
                foreach (var x in param)
                {
                    if (x.Value is Stream valueStream)
                        httpContent.Add(new StreamContent(valueStream), x.Key, "file");
                    else if (x.Value is IEnumerable<byte> valueBytes)
                        httpContent.Add(new ByteArrayContent(valueBytes.ToArray()), x.Key, "file");
                    else
                        httpContent.Add(new StringContent(x.Value.ToString()), x.Key);
                }
            }

            var response = await httpClient.PostAsync(url, httpContent).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }

        internal static async Task<AsyncResponse> HttpDeleteAsync(HttpClient httpClient, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var uri = Utils.CreateUrlParameter(url, param);
            var response = await httpClient.DeleteAsync(uri).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }

        internal static async Task<AsyncResponse> HttpPatchAsync(HttpClient httpClient, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            MultipartFormDataContent httpContent = null;
            if (param != null && param.Any())
            {
                httpContent = new MultipartFormDataContent();
                foreach (var x in param)
                {
                    if (x.Value is Stream valueStream)
                        httpContent.Add(new StreamContent(valueStream), x.Key, "file");
                    else if (x.Value is IEnumerable<byte> valueBytes)
                        httpContent.Add(new ByteArrayContent(valueBytes.ToArray()), x.Key, "file");
                    else
                        httpContent.Add(new StringContent(x.Value.ToString()), x.Key);
                }
            }

            var httpMethod = new HttpMethod("PATCH");
            var message = new HttpRequestMessage(httpMethod, url)
            {
                Content = httpContent
            };
            
            var response = await httpClient.SendAsync(message).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }

        internal static async Task<AsyncResponse> HttpPutAsync(HttpClient httpClient, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            MultipartFormDataContent httpContent = null;
            if (param != null && param.Any())
            {
                httpContent = new MultipartFormDataContent();
                foreach (var x in param)
                {
                    if (x.Value is Stream valueStream)
                        httpContent.Add(new StreamContent(valueStream), x.Key, "file");
                    else if (x.Value is IEnumerable<byte> valueBytes)
                        httpContent.Add(new ByteArrayContent(valueBytes.ToArray()), x.Key, "file");
                    else
                        httpContent.Add(new StringContent(x.Value.ToString()), x.Key);
                }
            }

            var response = await httpClient.PutAsync(url, httpContent).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }
    }
}
