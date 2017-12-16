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

            var uri = param == null ? url : Utils.CreateUrlParameter(url, param);
            var response = await httpClient.GetAsync(uri).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }

        internal static async Task<AsyncResponse> HttpPostAsync(HttpClient httpClient, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var httpContent = new MultipartFormDataContent();
            foreach (var x in param)
            {
                var valueStream = x.Value as Stream;
                var valueBytes = x.Value as IEnumerable<byte>;
                
                if (valueStream != null)
                    httpContent.Add(new StreamContent(valueStream), x.Key, "file");
                else if (valueBytes != null)
                    httpContent.Add(new ByteArrayContent(valueBytes.ToArray()), x.Key, "file");
                else
                    httpContent.Add(new StringContent(x.Value.ToString()), x.Key);
            }

            var uri = url;
            var response = await httpClient.PostAsync(uri, httpContent).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }

        internal static async Task<AsyncResponse> HttpDeleteAsync(HttpClient httpClient, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var uri = param == null ? url : Utils.CreateUrlParameter(url, param);
            var response = await httpClient.DeleteAsync(uri).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }

        internal static async Task<AsyncResponse> HttpPatchAsync(HttpClient httpClient, string url, IEnumerable<KeyValuePair<string, object>> param = null, IDictionary<string, string> headers = null)
        {
            if (headers != null)
                foreach (var header in headers)
                    httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);

            var httpContent = new MultipartFormDataContent();
            foreach (var x in param)
            {
                var valueStream = x.Value as Stream;
                var valueBytes = x.Value as IEnumerable<byte>;
                
                if (valueStream != null)
                    httpContent.Add(new StreamContent(valueStream), x.Key, "file");
                else if (valueBytes != null)
                    httpContent.Add(new ByteArrayContent(valueBytes.ToArray()), x.Key, "file");
                else
                    httpContent.Add(new StringContent(x.Value.ToString()), x.Key);
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

            var httpContent = new MultipartFormDataContent();
            foreach (var x in param)
            {
                var valueStream = x.Value as Stream;
                var valueBytes = x.Value as IEnumerable<byte>;

                if (valueStream != null)
                    httpContent.Add(new StreamContent(valueStream), x.Key, "file");
                else if (valueBytes != null)
                    httpContent.Add(new ByteArrayContent(valueBytes.ToArray()), x.Key, "file");
                else
                    httpContent.Add(new StringContent(x.Value.ToString()), x.Key);
            }

            var uri = url;
            var response = await httpClient.PutAsync(uri, httpContent).ConfigureAwait(false);
            var asyncResponse = new AsyncResponse(response);

            return asyncResponse;
        }
    }
}
